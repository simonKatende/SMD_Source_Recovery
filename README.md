# School Management Dynamics — source recovery

This repository contains the C# source code for the Alien Age School Management
Dynamics desktop application, recovered by decompiling the installed binaries
after the original source code was lost.

The recovery was completed on 2026-05-24. All 21 owned assemblies were
decompiled successfully (819 source files, ~77 MB of source). All 4
entry-point executables — `IXtreme.exe`, `LibraryManagement.exe`,
`MarksEntry.exe`, `ExtremeMessenger.exe` — have been rebuilt from source
at 99.8%+ size match with their originals. `IXtreme.exe` has additionally
been smoke-tested (launches, renders its Login form).

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

Pick any of the 4 entry-point EXEs (or all of them):

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj
dotnet build decompiled\LibraryManagement\LibraryManagement.csproj
dotnet build decompiled\MarksEntry\MarksEntry.csproj
dotnet build decompiled\ExtremeMessenger\ExtremeMessenger.csproj
```

Each output appears in the project's `bin\Debug\net472\` folder.

## Status of each project

The 4 entry-point EXEs build cleanly from source. The 17 library projects
were decompiled but not yet built from source — the EXEs currently link
against the original DLLs in `backup/` via `HintPath`, so they build
without the libraries being rebuilt.

| Project | Decompiled | Built | Smoke-tested |
|---|---|---|---|
| IXtreme | Yes | Yes (99.8%) | Yes (Login form renders) |
| LibraryManagement | Yes | Yes (99.8%) | No |
| MarksEntry | Yes | Yes (99.9%) | No |
| ExtremeMessenger | Yes | Yes (99.9%) | No |
| AlienAge.* (14 libraries) | Yes | No | No |
| SMDFastLane | Yes | No | No |
| BiotimeDevice | Yes | No | No |
| EventLogger | Yes | Yes | n/a (library) |

Percentages are rebuilt-EXE size as a fraction of original EXE size. The
small gap is mostly compiler-version differences and resource compression.

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
4. **Missing transitive DevExpress references** — explicit `<Reference>`
   entries added for assemblies the decompiler omitted but the code uses
   transitively: `DevExpress.Charts.v23.2.Core` (IXtreme),
   `DevExpress.Printing.v23.2.Core` and `DevExpress.Data.Desktop.v23.2`
   (LibraryManagement, MarksEntry, ExtremeMessenger),
   `DevExpress.Drawing.v23.2` (LibraryManagement).
5. **Decompiler artifacts**:
   - `ref array[0]` → `out array[0]` on 2 `SSR_GetUserTmp` callsites
     in IXtreme (`MainForm.cs`, `usrStudentList.cs`)
   - `FeesBalance(StudentNo, connectionString)` → `FeesBalance(StudentNo)`
     in IXtreme's `SynchPaymentsFromOnline.cs` (2 callsites)
   - `int num;` → `int num = 0;` in 3 unused `finally` blocks in IXtreme
   - `using DataTable = System.Data.DataTable;` alias added to disambiguate
     from `Microsoft.Office.Interop.Excel.DataTable` in: IXtreme
     (`StudentImport.cs`, `EmployeeImport.cs`), LibraryManagement
     (`BooksImport.cs`), MarksEntry (`MainALevel.cs`, `MainPrimary.cs`,
     `MainOLevelNewCur.cs`)
   - `using Point = System.Drawing.Point;` alias added to MarksEntry
     `MainALevel.cs` and `MainPrimary.cs` to disambiguate from
     `Microsoft.Office.Interop.Excel.Point`
   - `SqlCommand sqlCommand` → `SqlCommand cmd` in one block of
     MarksEntry's `MainALevel.cs` (CS0136 scope conflict — two declarations
     of the same name in nested/enclosing scopes within one method)
