# APDI RepSys

APDI RepSys is a Windows desktop reporting application for APDI.

It provides report workflows for:
- Sell Through
- System Sell Through
- GMROI
- RFMD summary and memo

## Solution Layout

- `APDIRepSys/`  
  Main WinForms application (`net8.0-windows`) that handles filtering, data updates, and report launch.
- `MyRep/`  
  WinForms Crystal Reports viewer (`.NET Framework 4.7.2`) launched by `APDIRepSys`.
- `APDIRepSys_Sn.sln`  
  Solution file with `x64` configurations.

## Tech Stack

- C#
- WinForms
- .NET 8 (`APDIRepSys`)
- .NET Framework 4.7.2 (`MyRep`)
- PostgreSQL
- ODBC + Npgsql
- Crystal Reports for .NET

## Prerequisites

- Windows machine
- Visual Studio 2022 (recommended)
- .NET 8 SDK
- .NET Framework 4.7.2 targeting pack
- Crystal Reports runtime/developer components installed
- ODBC DSNs available (project references these names):
- `PostgreSQL35W`
- `PostgreSQL35Wnew`
- Access to the `apdireports` PostgreSQL database

## Build and Run

1. Open `APDIRepSys_Sn.sln` in Visual Studio.
2. Select solution configuration `Debug | x64` (or `Release | x64`).
3. Set startup project to `APDIRepSys`.
4. Build solution.
5. Run `APDIRepSys`.

## Packaging

- Use the scripted packaging flow for reproducible release artifacts:
- `powershell -ExecutionPolicy Bypass -File .\scripts\build-package.ps1`
- Full guide:
- `docs/PACKAGING.md`

## Runtime Behavior

- `APDIRepSys` exports filtered XML files to:
- `%LocalAppData%\APDIRepSys\Reports`
- `APDIRepSys` launches `MyRep.exe` to preview Crystal Reports.
- `MyRep` expects `.rpt` files and XML files in the same `%LocalAppData%\APDIRepSys\Reports` path.

## Database Objects Used

Primary objects referenced by the application include:
- `gmroi_summary` (view)
- `sellthrough_mpc` (view)
- `sell_through_reports` (view)
- `system_sellthru_summary` (table)
- `rfmd_list_summary` (table)
- `rfmd_lineup_summary` (view)
- `product_images` (table)

## Important Caveats

- Mixed-framework solution: `.NET 8` and `.NET Framework 4.7.2` are both required.
- Crystal Reports is a hard dependency.
- Some DB and DSN settings are environment-specific.
- Current codebase contains legacy hardcoded connection usage in some forms; sanitize before external sharing.

## Recommended Next Cleanup

- Move all DB connection strings to environment-specific config.
- Remove hardcoded credentials from source.
- Add a first-run setup script/checklist for DSN and report file placement.
