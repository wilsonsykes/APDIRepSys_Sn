[CmdletBinding()]
param(
    [ValidateSet("Release", "Debug")]
    [string]$Configuration = "Release",

    [ValidateSet("x64")]
    [string]$Platform = "x64",

    [string]$RuntimeIdentifier = "win-x64",

    [string]$OutputRoot = "",

    [switch]$BuildAdvancedInstaller,

    [string]$AipPath = ""
)

$ErrorActionPreference = "Stop"

function Get-RepoRoot {
    $scriptRoot = Split-Path -Path $PSCommandPath -Parent
    return (Resolve-Path (Join-Path $scriptRoot "..")).Path
}

function Resolve-MSBuildPath {
    $vswhere = Join-Path ${env:ProgramFiles(x86)} "Microsoft Visual Studio\Installer\vswhere.exe"
    if (Test-Path $vswhere) {
        $path = & $vswhere -latest -products * -requires Microsoft.Component.MSBuild -find MSBuild\**\Bin\MSBuild.exe | Select-Object -First 1
        if (-not [string]::IsNullOrWhiteSpace($path)) {
            return $path
        }
    }

    $fallback = Get-Command msbuild -ErrorAction SilentlyContinue
    if ($fallback) {
        return $fallback.Source
    }

    throw "MSBuild.exe was not found. Install Visual Studio 2022 Build Tools or Visual Studio 2022."
}

function Resolve-AdvancedInstallerPath {
    $candidate = Get-ChildItem "C:\Program Files (x86)\Caphyon\*\bin\x86\AdvancedInstaller.com" -File -ErrorAction SilentlyContinue |
        Sort-Object FullName -Descending |
        Select-Object -First 1

    if ($candidate) {
        return $candidate.FullName
    }

    throw "AdvancedInstaller.com was not found under C:\Program Files (x86)\Caphyon."
}

function Assert-NoRunningAppProcess {
    $running = Get-Process APDIRepSys, MyRep -ErrorAction SilentlyContinue
    if ($running) {
        $list = ($running | ForEach-Object { "$($_.ProcessName) (PID $($_.Id))" }) -join ", "
        throw "Stop running app process(es) before packaging: $list"
    }
}

function Assert-FileExists {
    param(
        [string]$Path,
        [string]$Name
    )
    if (-not (Test-Path $Path)) {
        throw "Missing required file: $Name ($Path)"
    }
}

function Write-Section {
    param([string]$Text)
    Write-Host ""
    Write-Host "=== $Text ==="
}

$repoRoot = Get-RepoRoot
$solutionPath = Join-Path $repoRoot "APDIRepSys_Sn.sln"
$msbuildPath = Resolve-MSBuildPath

if ([string]::IsNullOrWhiteSpace($OutputRoot)) {
    $OutputRoot = Join-Path $repoRoot "artifacts"
}

$timestamp = Get-Date -Format "yyyyMMdd-HHmmss"
$stageRoot = Join-Path $OutputRoot "stage\APDIRepSys-$Configuration-$Platform"
$packageRoot = Join-Path $OutputRoot "packages"
$zipPath = Join-Path $packageRoot "APDIRepSys-$Configuration-$Platform-$timestamp.zip"

Write-Section "Preflight"
Assert-FileExists -Path $solutionPath -Name "Solution"
Assert-NoRunningAppProcess
Write-Host "MSBuild: $msbuildPath"
Write-Host "Solution: $solutionPath"

Write-Section "Build"
& $msbuildPath $solutionPath "/m" "/restore" "/t:Rebuild" "/p:Configuration=$Configuration" "/p:Platform=$Platform"
if ($LASTEXITCODE -ne 0) {
    throw "MSBuild failed with exit code $LASTEXITCODE"
}

$runtimeOutput = Join-Path $repoRoot "APDIRepSys\bin\$Platform\$Configuration\net8.0-windows\$RuntimeIdentifier"
Assert-FileExists -Path $runtimeOutput -Name "Runtime output folder"

Write-Section "Stage"
if (Test-Path $stageRoot) {
    Remove-Item $stageRoot -Recurse -Force
}
New-Item -Path $stageRoot -ItemType Directory -Force | Out-Null
Copy-Item -Path (Join-Path $runtimeOutput "*") -Destination $stageRoot -Recurse -Force

$requiredFiles = @(
    "APDIRepSys.exe",
    "MyRep.exe",
    "MyRep.exe.config",
    "CrystalDecisions.CrystalReports.Engine.dll",
    "CrystalDecisions.Shared.dll"
)

foreach ($file in $requiredFiles) {
    Assert-FileExists -Path (Join-Path $stageRoot $file) -Name $file
}

$manifestPath = Join-Path $stageRoot "manifest.sha256"
Get-ChildItem -Path $stageRoot -Recurse -File |
    Where-Object { $_.FullName -ne $manifestPath } |
    Sort-Object FullName |
    ForEach-Object {
        $hash = (Get-FileHash $_.FullName -Algorithm SHA256).Hash.ToLowerInvariant()
        $relative = $_.FullName.Substring($stageRoot.Length + 1).Replace('\', '/')
        "{0}  {1}" -f $hash, $relative
    } | Set-Content -Path $manifestPath -Encoding UTF8

Write-Section "Archive"
New-Item -Path $packageRoot -ItemType Directory -Force | Out-Null
if (Test-Path $zipPath) {
    Remove-Item $zipPath -Force
}
Compress-Archive -Path (Join-Path $stageRoot "*") -DestinationPath $zipPath -CompressionLevel Optimal

Write-Host "Stage folder: $stageRoot"
Write-Host "Package zip: $zipPath"
Write-Host "Manifest: $manifestPath"

if ($BuildAdvancedInstaller) {
    Write-Section "Advanced Installer"
    if ([string]::IsNullOrWhiteSpace($AipPath)) {
        throw "When -BuildAdvancedInstaller is used, -AipPath must point to your .aip project."
    }

    $resolvedAipPath = (Resolve-Path $AipPath).Path
    Assert-FileExists -Path $resolvedAipPath -Name "Advanced Installer project"

    $advancedInstallerPath = Resolve-AdvancedInstallerPath
    Write-Host "AdvancedInstaller.com: $advancedInstallerPath"
    Write-Host "AIP: $resolvedAipPath"

    & $advancedInstallerPath /build $resolvedAipPath
    if ($LASTEXITCODE -ne 0) {
        throw "Advanced Installer build failed with exit code $LASTEXITCODE"
    }
}

Write-Section "Done"
Write-Host "Packaging completed successfully."
