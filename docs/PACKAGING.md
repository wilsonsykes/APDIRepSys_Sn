# Packaging Guide

This solution is a mixed framework app:

- `APDIRepSys` (`net8.0-windows`)
- `MyRep` (`.NET Framework 4.7.2`, Crystal Reports)

Because of this, use **Visual Studio MSBuild** for release packaging.  
`dotnet publish` alone is not reliable for the full solution.

## Prerequisites

- Visual Studio 2022 (or Build Tools with MSBuild)
- Crystal Reports runtime/developer components installed
- All app instances closed before build (`APDIRepSys.exe`, `MyRep.exe`)

Optional:

- Advanced Installer (if you also build `.aip` from CLI)

## Recommended Command

From repo root:

```powershell
powershell -ExecutionPolicy Bypass -File .\scripts\build-package.ps1
```

This will:

1. Rebuild solution with `Release|x64`
2. Stage runtime files from `APDIRepSys\bin\x64\Release\net8.0-windows\win-x64`
3. Validate critical files (`APDIRepSys.exe`, `MyRep.exe`, Crystal DLLs)
4. Generate `manifest.sha256`
5. Create a zip package under `artifacts\packages`

## Advanced Installer Build (Optional)

If you have an `.aip` installer project:

```powershell
powershell -ExecutionPolicy Bypass -File .\scripts\build-package.ps1 `
  -BuildAdvancedInstaller `
  -AipPath "C:\path\to\YourInstaller.aip"
```

## GitHub Release Workflow

Workflow file:

- `.github/workflows/release-installer.yml`

What it does:

1. Rebuilds the solution on a Windows runner.
2. Runs `scripts/build-package.ps1`.
3. Collects generated zip (and MSI when enabled).
4. Publishes them as GitHub Release assets.

Runner requirement:

- Use a **self-hosted Windows x64 runner** with:
- Visual Studio/MSBuild
- Crystal Reports dependencies
- Advanced Installer (if MSI build is enabled)
- Access to the `.aip` path configured in workflow inputs

How to run:

1. Go to `Actions` -> `Build And Release Installer`.
2. Click `Run workflow`.
3. Set `tag` (example: `v3.2.0`) and keep defaults or adjust `aip_path`.
4. Run.

## Common Failures

- `file is locked`:
  - Close `APDIRepSys.exe` / `MyRep.exe` and rerun.
- `GenerateResource task host x86` when using `dotnet publish`:
  - Use the provided script (MSBuild path via Visual Studio).
- Missing Crystal runtime DLLs:
  - Ensure SAP Crystal Reports for Visual Studio is installed on build machine.
