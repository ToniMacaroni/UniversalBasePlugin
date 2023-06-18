param (
    [Parameter(Mandatory=$true)]
    [string]$ProjectName,

    [Parameter(Mandatory=$true)]
    [string]$NewProjectDir
)

$templateDir = $PSScriptRoot
$oldStr = 'UniversalBasePlugin'
$newStr = $projectName
$NewProjectDir = Join-Path $NewProjectDir $ProjectName

if (Test-Path $NewProjectDir) {
    Write-Output "Error: Directory $NewProjectDir already exists"
    return
}

Copy-Item $templateDir $NewProjectDir -Recurse

Get-ChildItem $NewProjectDir -Recurse | ForEach-Object {
    $extension = $_.Extension
    if ('.cs', '.csproj', '.sln', '.md', '.txt', '.gitignore', '.yml', '.py', '.user' -notcontains $extension) { return }

    if ($_.Name -like "*$oldStr*") {
        $newName = $_.Name.Replace($oldStr, $newStr)
        Rename-Item -Path $_.FullName -NewName $newName
    }
}

Get-ChildItem $NewProjectDir -Recurse -Directory | ForEach-Object {
    if ($_.Name -like "*$oldStr*") {
        $newName = $_.Name.Replace($oldStr, $newStr)
        Rename-Item -Path $_.FullName -NewName $newName
    }
}

Get-ChildItem $NewProjectDir -Recurse | ForEach-Object {
    $extension = $_.Extension
    if ('.cs', '.csproj', '.sln', '.md', '.txt', '.gitignore', '.yml', '.py' -notcontains $extension) { return }

    Write-Output "Replacing $oldStr with $newStr in $($_.Name)"
    $fileData = Get-Content $_.FullName -Raw

    if ($fileData -like "*$oldStr*") {
        $fileData = $fileData.Replace($oldStr, $newStr)
        Set-Content -Path $_.FullName -Value $fileData
    }

    $lowercase = $oldStr.ToLower()
    if ($fileData -like "*$lowercase*") {
        $fileData = $fileData.Replace($lowercase, $newStr.ToLower())
        Set-Content -Path $_.FullName -Value $fileData
    }
}

Remove-Item -Path (Join-Path $NewProjectDir 'Scaffold.ps1')
Remove-Item -Path (Join-Path $NewProjectDir 'Scaffold.bat')

Write-Output "Created project $NewProjectDir"