<#
.SYNOPSIS
    Rebuild the School Management Dynamics MSI (SMD_Ultimate.msi) from the
    recovered WiX source, with a freshly-built IXtreme.exe swapped in.

.DESCRIPTION
    The installer source (SMD_Ultimate.wxs) was recovered by decompiling the
    original SMD_Ultimate.msi with WiX v3's dark.exe. The third-party payload
    files (DevExpress, ZK BiotimeSDK, AlienAge.*.v4 libraries, the other three
    EXEs, etc.) are NOT in git -- they are extracted from the original MSI on
    demand into installer\payload\ (gitignored, same rule as backup\).

    Only IXtreme.exe is rebuilt from this repo's source; every other payload is
    carried over unchanged from the original MSI.

    Steps:
      1. Ensure WiX v3.14 toolset is present (tools\wix314\).
      2. If installer\payload\ is missing, run dark.exe to extract it from the
         original MSI.
      3. Build IXtreme.exe (Release/x86) from decompiled\IXtreme.
      4. Copy the built IXtreme.exe over installer\payload\File\IXtreme.exe.
      5. candle + light -> installer\SMD_Ultimate.msi.

    ICE validation is suppressed (-sval) because the original installer uses
    advertised shortcuts that WiX's ICE19/ICE50 reject; this matches how the
    original MSI was built.

.NOTES
    Bump <Product Version="..."> in SMD_Ultimate.wxs for each release. The
    Product Id is "*" so a fresh ProductCode is generated every build, while the
    UpgradeCode is fixed so new versions cleanly replace older installs.
#>
[CmdletBinding()]
param(
    [string]$RepoRoot   = (Split-Path $PSScriptRoot -Parent),
    [string]$OriginalMsi= 'D:\Setups\System Management Dynamics\System Management Dynamics\SMD_Ultimate.msi',
    [switch]$SkipIXtremeBuild
)

$ErrorActionPreference = 'Stop'
$wixBin   = Join-Path $RepoRoot 'tools\wix314'
$instDir  = Join-Path $RepoRoot 'installer'
$payload  = Join-Path $instDir 'payload'
$wxs      = Join-Path $instDir 'SMD_Ultimate.wxs'
$wixobj   = Join-Path $instDir 'SMD_Ultimate.wixobj'
$outMsi   = Join-Path $instDir 'SMD_Ultimate.msi'
$ixProj   = Join-Path $RepoRoot 'decompiled\IXtreme\IXtreme.csproj'
$ixBuilt  = Join-Path $RepoRoot 'decompiled\IXtreme\bin\x86\Release\net472\IXtreme.exe'

function Require-File($path, $hint) {
    if (-not (Test-Path $path)) { throw "Required file not found: $path`n$hint" }
}

# 1. WiX toolset
Require-File "$wixBin\candle.exe" "Download WiX v3.14 binaries to tools\wix314\ (https://github.com/wixtoolset/wix3/releases)."
Require-File "$wixBin\light.exe"  "Download WiX v3.14 binaries to tools\wix314\."

# 2. Extract payload from the original MSI if not already present
if (-not (Test-Path (Join-Path $payload 'File\IXtreme.exe'))) {
    Require-File $OriginalMsi "Point -OriginalMsi at the original SMD_Ultimate.msi to extract the third-party payload."
    Write-Host "Extracting payload from original MSI via dark.exe..."
    & "$wixBin\dark.exe" $OriginalMsi -x $payload -o (Join-Path $instDir '_dark_roundtrip.wxs') -sw1108 | Out-Null
    Remove-Item (Join-Path $instDir '_dark_roundtrip.wxs') -ErrorAction SilentlyContinue
}

# 3. Build IXtreme.exe (Release/x86)
if (-not $SkipIXtremeBuild) {
    Write-Host "Building IXtreme.exe (Release/x86)..."
    dotnet build $ixProj -c Release /p:Platform=x86 -v minimal
    if ($LASTEXITCODE -ne 0) { throw "IXtreme build failed (exit $LASTEXITCODE)." }
}
Require-File $ixBuilt "IXtreme.exe was not produced by the Release build."

# 4. Sync the payload with IXtreme's tested build output.
#    IXtreme references the AlienAge.*.v4 libraries as ProjectReferences, so building it
#    rebuilds the whole managed runtime set (IXtreme.exe, AlienAge.* libs, SMDFastLane) and
#    copies it -- plus System.Resources.Extensions and friends (the rebuilt EXE uses
#    preserialized binary resources) -- into its output dir. The original MSI shipped STALE
#    versions of these (e.g. an AlienAge.ExtremeMessenger.v4.dll missing TrySendSMSViaPOST,
#    which crashed payment with MissingMethodException). So for every assembly the build
#    produces whose name matches a payload File, copy the fresh version over the stale one.
#    DevExpress/ZK third-party DLLs are byte-identical and simply stay in sync.
$ixDir = Split-Path $ixBuilt -Parent
$wxsText = Get-Content $wxs -Raw
$nameToSource = @{}
[regex]::Matches($wxsText, '<File\b[^>]*>') | ForEach-Object {
    $tag = $_.Value
    $n = [regex]::Match($tag, 'Name="([^"]+)"').Groups[1].Value
    $s = [regex]::Match($tag, 'Source="([^"]+)"').Groups[1].Value
    if ($n -and $s) { $nameToSource[$n] = $s }
}
Write-Host "Syncing payload with IXtreme build output..."
$synced = 0
Get-ChildItem $ixDir -File -Recurse -Include *.dll,*.exe,*.config | ForEach-Object {
    if ($nameToSource.ContainsKey($_.Name)) {
        $dest = $nameToSource[$_.Name]
        $new  = (Get-FileHash $_.FullName -Algorithm SHA256).Hash
        $old  = (Test-Path $dest) ? (Get-FileHash $dest -Algorithm SHA256).Hash : ''
        if ($new -ne $old) { Copy-Item $_.FullName $dest -Force; $synced++; Write-Host "  refreshed $($_.Name)" }
    }
}
Write-Host "  $synced payload file(s) updated."

# 5. Compile + link
Write-Host "candle..."
& "$wixBin\candle.exe" $wxs -out $wixobj -ext WixUIExtension
if ($LASTEXITCODE -ne 0) { throw "candle failed (exit $LASTEXITCODE)." }

Write-Host "light..."
& "$wixBin\light.exe" $wixobj -out $outMsi -ext WixUIExtension -sval
if ($LASTEXITCODE -ne 0) { throw "light failed (exit $LASTEXITCODE)." }

$sz = [math]::Round((Get-Item $outMsi).Length / 1MB, 1)
Write-Host ""
Write-Host "Built: $outMsi ($sz MB)" -ForegroundColor Green
