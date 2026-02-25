@echo off
setlocal

set "SCRIPT_DIR=%~dp0"
set "PS_SCRIPT=%SCRIPT_DIR%build-package.ps1"
set "DEFAULT_AIP=C:\Users\OP5\Documents\Advanced Installer\Projects\APDI Reporting System\APDI Reporting System.aip"

if not exist "%PS_SCRIPT%" (
  echo [ERROR] Missing PowerShell script: "%PS_SCRIPT%"
  exit /b 1
)

if "%~1"=="" (
  set "AIP_PATH=%DEFAULT_AIP%"
) else (
  set "AIP_PATH=%~1"
)

if not exist "%AIP_PATH%" (
  echo [ERROR] AIP file not found: "%AIP_PATH%"
  echo.
  echo Usage:
  echo   build-installer.cmd
  echo   build-installer.cmd "C:\path\to\your.aip"
  exit /b 1
)

echo Running rebuild + package + Advanced Installer build...
echo AIP: "%AIP_PATH%"
echo.

powershell -NoProfile -ExecutionPolicy Bypass -File "%PS_SCRIPT%" ^
  -Configuration Release ^
  -Platform x64 ^
  -BuildAdvancedInstaller ^
  -AipPath "%AIP_PATH%"

set "EXIT_CODE=%ERRORLEVEL%"
echo.
if not "%EXIT_CODE%"=="0" (
  echo [FAILED] Build/packaging failed with exit code %EXIT_CODE%.
  exit /b %EXIT_CODE%
)

echo [OK] Build/packaging completed successfully.
exit /b 0
