# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this repo is

This is a **source-recovery project**, not a greenfield codebase. The original C# source for the Alien Age School Management Dynamics desktop application was lost; what lives here was reconstructed by decompiling the installed binaries with `ilspycmd`. Treat the code as recovered artifact — names, layout, and oddities reflect what the decompiler emitted, not deliberate design choices.

Recovery completed 2026-05-24. 21 assemblies (~819 source files, ~77 MB) were decompiled. The 4 entry-point EXEs (`IXtreme`, `LibraryManagement`, `MarksEntry`, `ExtremeMessenger`) rebuild from source at 99.8%+ size match with the originals; the 17 library projects are decompiled but not yet rebuilt — the EXEs link against the original DLLs in `backup/` via `HintPath`.

## Repository layout

| Folder | In git? | Notes |
|---|---|---|
| `decompiled/` | yes | One project per original assembly (21 total). Build inputs live here. |
| `notes/` | yes | Reproduction scripts (`decompile_all.ps1`, `gen_interop.ps1`) + per-build logs. |
| `backup/` | **no** | Frozen mirror of `C:\Program Files (x86)\Alien Age\School Management Dynamics\`. All `.csproj` files reference it via `HintPath="..\..\backup\<dll>"`. Must be recreated locally before any build. |
| `smoke_test/` | no | Runtime deployment used to validate that a rebuilt EXE launches. Mirror of `backup/` plus the freshly-built EXE and its `.exe.config`. |
| `reconstructed/` | yes (empty) | Reserved for a future unified `.sln`. |

## Setting up a fresh machine

```powershell
# 1. Recreate backup/ from the installed app
robocopy "C:\Program Files (x86)\Alien Age\School Management Dynamics" `
         "<repo>\backup" /E /COPY:DAT

# 2. Generate the ZK fingerprint COM interop (must run under Windows PowerShell 5.1,
#    not pwsh — it needs the full .NET Framework's TypeLibConverter)
powershell.exe -ExecutionPolicy Bypass -File notes\gen_interop.ps1

# 3. .NET 8 SDK (used to invoke the net472-targeted build)
winget install Microsoft.DotNet.SDK.8
```

## Build

```powershell
dotnet build decompiled\IXtreme\IXtreme.csproj
dotnet build decompiled\LibraryManagement\LibraryManagement.csproj
dotnet build decompiled\MarksEntry\MarksEntry.csproj
dotnet build decompiled\ExtremeMessenger\ExtremeMessenger.csproj
```

Output lands in each project's `bin\Debug\net472\`. There is **no test suite**; verification is "does the EXE launch and render its first form" via the `smoke_test/` deployment.

## Project shape

- SDK: `Microsoft.NET.Sdk.WindowsDesktop` (WinForms).
- Target: `net472`, `PlatformTarget=x86`, `LangVersion=11.0`, `AllowUnsafeBlocks=true`.
- Every entry-point csproj sets `<GenerateResourceUsePreserializedResources>true</GenerateResourceUsePreserializedResources>` and `PackageReference Include="System.Resources.Extensions"` — required because the decompiled `.resx` files contain binary-formatted resources. The matching `IXtreme.exe.config` adds a binding redirect so the runtime resolves `System.Resources.Extensions 8.0.0`.
- UI framework is DevExpress v23.2 (XtraBars/XtraGrid/XtraReports/XtraCharts/etc.). Sister libraries live under the `AlienAge.*` namespace.
- Fingerprint hardware via the ZK biometric SDK (`Interop.zkemkeeper.dll`, generated from a registered TypeLib — not redistributable, hence `gen_interop.ps1`).
- COM interops (`Microsoft.Office.Interop.Excel`, `office`, `Interop.zkemkeeper`) are referenced with `EmbedInteropTypes=True`. Do not check in the decompiled `Microsoft.Office.Interop.Excel/` folder — reference the real PIA instead.

## Working with decompiled code — recurring fixes

The decompiler emits valid-looking C# that doesn't quite compile. These are the patterns that have come up in `IXtreme`, `LibraryManagement`, `MarksEntry`, `ExtremeMessenger`. Expect the same classes of issue in the 17 library projects when they're eventually built.

1. **`ref array[0]` should be `out array[0]`** — for `SSR_GetUserTmp` callsites (seen in `MainForm.cs`, `usrStudentList.cs`).
2. **Phantom overload** — `FeesBalance(StudentNo, connectionString)` doesn't exist; drop the second arg (seen in `SynchPaymentsFromOnline.cs`).
3. **Unassigned locals in `finally`** — `int num;` in an unused `finally` block compiles in IL but not in C#; initialize to `0`.
4. **`DataTable` ambiguity** — collides between `System.Data.DataTable` and `Microsoft.Office.Interop.Excel.DataTable`. Add `using DataTable = System.Data.DataTable;` to the affected file (`StudentImport.cs`, `EmployeeImport.cs`, `BooksImport.cs`, `MainALevel.cs`, `MainPrimary.cs`, `MainOLevelNewCur.cs`).
5. **`Point` ambiguity** — same problem between `System.Drawing.Point` and `Microsoft.Office.Interop.Excel.Point`. Add `using Point = System.Drawing.Point;`.
6. **CS0136 scope conflicts** — inner-scope variable shadows an enclosing-scope variable with the same name. The decompiler doesn't notice; rename one (e.g. `SqlCommand sqlCommand` → `SqlCommand cmd` in `MarksEntry/MainALevel.cs`).
7. **Missing transitive DevExpress references** — the decompiler lists only directly-used assemblies. When the compiler complains about an unresolved type from a DevExpress namespace, add an explicit `<Reference>` to the relevant `DevExpress.*.v23.2.dll` in `backup/`. Already added across the four EXEs: `DevExpress.Charts.v23.2.Core`, `DevExpress.Printing.v23.2.Core`, `DevExpress.Data.Desktop.v23.2`, `DevExpress.Drawing.v23.2`.

**Rule of thumb when fixing decompiler artifacts:** preserve byte-for-byte behavior. The goal is "rebuilt EXE matches original size to within ~0.2%," not refactoring. Don't tidy up odd identifier names, don't collapse generated `dSet*`/`HelperDS` DataSet partials, don't reorganize files.

## Conventions to respect

- **Don't commit `backup/` or `smoke_test/`** — both are gitignored. They contain third-party DLLs (DevExpress, ZK SDK, etc.) that are not ours to redistribute.
- **Build logs go to `notes/`** — never let `*.binlog` or scratch log files land in project folders. The convention is `notes\<Project>_buildN.log`.
- **Per-project, not per-solution** — there is no `.sln`. Build each `.csproj` directly with `dotnet build`. If a solution is later assembled, it goes in `reconstructed/`.
- **Recovery details belong in commit messages.** When you fix a new class of decompiler artifact, document the pattern in the commit message (filename, line, before → after) so the README and this file can be updated from `git log`.
