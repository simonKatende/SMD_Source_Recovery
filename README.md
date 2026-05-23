# School Management Dynamics — source recovery

This repository contains the C# source code for the Alien Age School Management
Dynamics desktop application, recovered by decompiling the installed binaries
after the original source code was lost.

The recovery was completed on 2026-05-24. All 21 owned assemblies were
decompiled successfully (819 source files, ~77 MB of source). The main
application (`IXtreme.exe`) has been rebuilt from this source and verified
to launch and render its Login form.

## Layout

| Folder | Purpose | In git? |
|---|---|---|
| `decompiled/` | Recovered source — 21 projects, one per original assembly | Yes |
| `notes/` | Scripts to reproduce the recovery, build logs | Yes |
| `backup/` | Frozen mirror of the install folder (third-party DLLs the projects link against) | **No — recreate locally** |
| `smoke_test/` | Runtime test deployment | No |
| `reconstructed/` | Reserved for a future unified `.sln` | Yes (empty) |

## Setting up to build on a fresh machine

### 1. Recreate `backup/`

The `.csproj` files reference third-party DLLs (DevExpress, ZK biometric SDK,
Entity Framework, Newtonsoft.Json, AlienAge sister libraries) via
`HintPath="..\..\backup\<dll>"`. Recreate this folder by mirroring the
installed application:

```powershell
robocopy "C:\Program Files (x86)\Alien Age\School Management Dynamics" `
         "<repo-root>\backup" /E /COPY:DAT
```

### 2. Generate the COM interop for the ZK fingerprint reader

`Interop.zkemkeeper.dll` is generated from the registered ZK COM library.
Once `backup/` is in place, run:

```powershell
powershell.exe -ExecutionPolicy Bypass -File notes\gen_interop.ps1
```

This drops `Interop.zkemkeeper.dll` into `backup/`.

### 3. Install the .NET 8 SDK

```powershell
winget install Microsoft.DotNet.SDK.8
```

### 4. Build

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj
```

The output appears in `decompiled\IXtreme\bin\Debug\net472\`.

## Status of each project

Only `IXtreme` has been built and verified end-to-end. The other 20 projects
were decompiled but not yet built — they currently exist as raw decompiler
output. They were referenced by `IXtreme` via `HintPath` to their original
DLLs in `backup/`, so the main app builds without them being built from
source.

| Project | Decompiled | Built | Smoke-tested |
|---|---|---|---|
| IXtreme | Yes | Yes | Yes (Login form renders) |
| LibraryManagement | Yes | No | No |
| MarksEntry | Yes | No | No |
| ExtremeMessenger | Yes | No | No |
| AlienAge.* (14 libraries) | Yes | No | No |
| SMDFastLane | Yes | No | No |
| BiotimeDevice | Yes | No | No |
| EventLogger | Yes | Yes | n/a (library) |

## Known fixes applied during recovery

Recorded in detail in commit history. Summary:

1. **Binary `.resx` resources** — added
   `<GenerateResourceUsePreserializedResources>true</GenerateResourceUsePreserializedResources>`
   and a `System.Resources.Extensions` package reference. The runtime
   counterpart is the binding redirect in the generated `IXtreme.exe.config`.
2. **Excel embedded interop** — deleted the decompiled
   `Microsoft.Office.Interop.Excel/` folder and referenced the real PIA
   with `EmbedInteropTypes=True`.
3. **ZK COM interop** — generated `Interop.zkemkeeper.dll` from the registered
   TypeLib via `notes\gen_interop.ps1` (uses `TypeLibConverter`), referenced
   with `EmbedInteropTypes=True`.
4. **Missing chart reference** — added explicit `<Reference>` for
   `DevExpress.Charts.v23.2.Core`.
5. **Decompiler artifacts**:
   - `ref array[0]` → `out array[0]` on 2 `SSR_GetUserTmp` callsites
     (`MainForm.cs`, `usrStudentList.cs`)
   - `FeesBalance(StudentNo, connectionString)` → `FeesBalance(StudentNo)`
     in `SynchPaymentsFromOnline.cs` (2 callsites)
   - `int num;` → `int num = 0;` in 3 unused `finally` blocks
   - `using DataTable = System.Data.DataTable;` alias added to
     `StudentImport.cs` and `EmployeeImport.cs` to disambiguate from
     `Microsoft.Office.Interop.Excel.DataTable`
