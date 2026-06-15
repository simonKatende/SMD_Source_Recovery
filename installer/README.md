# Installer (SMD_Ultimate.msi) recovery + rebuild

The original product installer, `SMD_Ultimate.msi`, was authored with the
**WiX Toolset v3** but — like the application source — only the compiled MSI
survived; the `.wxs` source was lost. It was recovered the same way the app was:
by decompiling the binary.

- **Recovery tool:** WiX v3.14 `dark.exe` (`dark SMD_Ultimate.msi -x payload out.wxs`)
- **Recovered source:** [`SMD_Ultimate.wxs`](SMD_Ultimate.wxs) (checked in)
- **Payload:** `payload/` — third-party files (DevExpress, ZK BiotimeSDK,
  `AlienAge.*.v4` libraries, the other three EXEs, SQL scripts, ID templates)
  extracted from the original MSI. **Gitignored** — not ours to redistribute,
  same rule as `backup/`.

## What this installer contains

A WiX `WixUI_FeatureTree` wizard that lets each machine install all or part of
the product. Features:

| Feature | Level | Installs |
|---|---|---|
| School Management Dynamics | 1 | `IXtreme.exe` + DevExpress + BiotimeSDK + registry/shortcuts (the core) |
| Library Module | 1 | `LibraryManagement.exe` |
| Teachers' Workstation | 1 | `MarksEntry.exe` |
| SMD Messenger Module | 1 | `ExtremeMessenger.exe` |
| Server Tools | 4 | Server Tools + SQL SMO + 4 sync services |
| Attendance Tracker Service | 4 | Attendance Windows service |
| Islamic Theology | 4 | `IslamicTheology.exe` (ArabicTheology) |

Level 4 features are unchecked by default in the wizard.

## What changed in this build (25.1.9.6)

`IXtreme.exe` **and the `AlienAge.*.v4` libraries it references** are rebuilt
from this repo's source. IXtreme references those libraries as ProjectReferences,
so building it rebuilds the whole managed runtime set; step 4 of `build.ps1` then
copies every produced assembly whose name matches a payload file over the stale
original. The other three EXEs (Library/MarksEntry/Messenger), IslamicTheology,
the services, DevExpress and the ZK SDK are unchanged and carried over from the
original MSI payload.

### 25.1.9.6 fixes (post-deploy crash reports)
- **Payment crash (`MissingMethodException: ...SMSGateWay.TrySendSMSViaPOST`).**
  The 25.1.9.5 MSI shipped the *original* `AlienAge.ExtremeMessenger.v4.dll`
  (extracted from the old MSI), which predates `TrySendSMSViaPOST` — but the
  rebuilt `IXtreme.exe` calls it. Root cause: the installer payload was synced
  only for `IXtreme.exe`, not the rebuilt libraries. Fixed by syncing **all**
  IXtreme runtime assemblies (see step 4) so the shipped DLL matches what IXtreme
  was built and tested against.
- **Send Reminders returned the egosms HTML login page instead of sending.**
  `FeeSmsHelper` built its request URL from `tbl_SMSAccount.url`; that column held
  a portal/host URL (e.g. `https://www.egosms.co`), harmless for years because the
  old gateway hardcoded the `/plain` endpoint and ignored it. The newer code
  honoured it and hit the portal, which serves the login page. Fixed with
  `SmsReminderLogic.ResolveSmsBaseUrl`, which only trusts a configured URL that
  looks like a real plain-API endpoint (`/api/` or `/plain`) and otherwise falls
  back to `https://www.egosms.co/api/v1/plain/?`. (If SMS still fails after this,
  check the egosms **account credentials/balance** — that is data, not code.)

The rebuilt `IXtreme.exe` uses preserialized (binary-formatted) `.resx`
resources, so unlike the original it needs `System.Resources.Extensions` plus
the binding redirect in `IXtreme.exe.config` at runtime. The original installer
shipped none of these, so a new component **`IXtremeRuntime`** (in the core
`ProductFeature`) installs them alongside `IXtreme.exe`:
`IXtreme.exe.config`, `System.Resources.Extensions.dll`, `System.Memory.dll`,
`System.Buffers.dll`, `System.Numerics.Vectors.dll`,
`System.Runtime.CompilerServices.Unsafe.dll`. Without this, IXtreme installs but
throws when loading any form with binary resources.

Version metadata:
- `Version` `25.1.9.6` (25.1.9.4 original -> 25.1.9.5 first rebuild -> 25.1.9.6 crash fixes)
- `Product Id="*"` (fresh ProductCode each build)
- `UpgradeCode` unchanged -> installing this cleanly upgrades an existing install
  (`MajorUpgrade`, scheduled `afterInstallValidate`).

## Rebuild

```powershell
# from the repo root
powershell -ExecutionPolicy Bypass -File installer\build.ps1
```

The script extracts `payload/` from the original MSI if missing, builds
`IXtreme.exe` (Release/x86), swaps it in, and runs `candle` + `light`. Output:
`installer\SMD_Ultimate.msi`.

Prerequisites:
- WiX v3.14 binaries in `tools\wix314\` (`dark`/`candle`/`light`).
- The original `SMD_Ultimate.msi` reachable (default path is on `D:\Setups\...`;
  override with `-OriginalMsi`) — needed once to extract the payload.
- .NET 8 SDK (to build the net472 IXtreme project).

## Notes / gotchas

- **ICE validation is suppressed** (`light -sval`). The original installer uses
  *advertised* shortcuts, which WiX's ICE19/ICE50 reject; the original MSI was
  built the same way. The shortcuts work correctly at install time.
- **Plaintext DB defaults.** `SMD_Ultimate.wxs` writes HKCU connection defaults
  (`Server=.\SqlExpress`, `Database=IXtreme_Ultimate`, `UID=sa`, a plaintext
  `Password`) carried over from the original installer. These are only initial
  values; the app's Connect-to-Database screen overrides them on first run. Left
  as-is to preserve original behavior — revisit if distributing more widely.
- The MSI is ~258 MB; that is normal (the embedded DevExpress assemblies
  dominate) and matches the original's size.
