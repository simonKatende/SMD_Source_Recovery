$env:DOTNET_ROLL_FORWARD = "LatestMajor"
$ilspy = "$env:USERPROFILE\.dotnet\tools\ilspycmd.exe"
$backup = "C:\SMD_Source_Recovery\backup"
$outRoot = "C:\SMD_Source_Recovery\decompiled"

$owned = @(
    'EventLogger.dll',
    'BiotimeDevice.dll',
    'SMDFastLane.dll',
    'AlienAge.DataSync.v4.dll',
    'AlienAge.Accounts.v4.dll',
    'AlienAge.Semesters.v4.dll',
    'AlienAge.ExtremeMessenger.v4.dll',
    'AlienAge.CustomGrid.v4.dll',
    'AlienAge.Security.v4.dll',
    'AlienAge.CommonSettings.v4.dll',
    'AlienAge.Connectivity.v4.dll',
    'AlienAge.SubjectRegistration.v4.dll',
    'AlienAge.ReportHeaders.v4.dll',
    'AlienAge.GradingScales.v4.dll',
    'AlienAge.TermlySettings.v4.dll',
    'AlienAge.ArabicTheology.v4.dll',
    'ExtremeMessenger.exe',
    'LibraryManagement.exe',
    'MarksEntry.exe',
    'AlienAge.ReportDesigner.v4.dll',
    'IXtreme.exe'
)

$results = @()
$startedAll = Get-Date

foreach ($asm in $owned) {
    $src = Join-Path $backup $asm
    $name = [System.IO.Path]::GetFileNameWithoutExtension($asm)
    $out = Join-Path $outRoot $name
    if (Test-Path $out) { Remove-Item $out -Recurse -Force }
    New-Item -ItemType Directory -Path $out -Force | Out-Null

    $sz = [math]::Round((Get-Item $src).Length / 1KB, 1)
    Write-Output "==========================================================="
    Write-Output "[$([DateTime]::Now.ToString('HH:mm:ss'))] $asm ($sz KB)"
    Write-Output "==========================================================="
    $start = Get-Date
    & $ilspy $src -p -o $out -r $backup 2>&1 | Out-String | Out-Null
    $elapsed = [math]::Round(((Get-Date) - $start).TotalSeconds, 1)
    $files = (Get-ChildItem $out -Recurse -File).Count
    $bytes = ((Get-ChildItem $out -Recurse -File) | Measure-Object Length -Sum).Sum
    $kb = [math]::Round($bytes / 1KB, 1)
    Write-Output "    => $files files, $kb KB, $elapsed sec"
    $results += [PSCustomObject]@{ Assembly=$asm; SizeKB=$sz; OutFiles=$files; OutKB=$kb; ElapsedSec=$elapsed }
}

Write-Output ""
Write-Output "==========================================================="
Write-Output "DONE. Total elapsed: $([math]::Round(((Get-Date) - $startedAll).TotalMinutes, 1)) min"
Write-Output "==========================================================="
$results | Format-Table -AutoSize | Out-String | Write-Output
$results | Export-Csv "C:\SMD_Source_Recovery\notes\decompile_results.csv" -NoTypeInformation
Write-Output "Results saved to notes\decompile_results.csv"
