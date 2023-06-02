param (
    [Parameter(Mandatory = $true)]
    [string]$path,

    [Parameter(Mandatory = $true)]
    [DateTime]$dateTime
)


if (-not (Test-Path $path)) {
    "Directory does not exist!." | Out-File 'Report.txt'
    return
}

if (Test-Path $path -PathType Leaf) {
    "Directory does not exist!." | Out-File 'Report.txt'
    return
}

$files = Get-ChildItem -Path $path -File | Where-Object { $_.LastWriteTime -gt $dateTime } | Sort-Object -Property Name -Descending

$content = ""
Foreach ($file in $files)
{
    Write-Host $file.Name
    $content = $content + $file.Name + "`n"
}

$content = $content.TrimEnd("`n")

$content | Out-File 'Report.txt'