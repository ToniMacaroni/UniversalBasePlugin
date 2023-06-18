@echo off
setlocal

:prompt
echo.
set /p "projectName=Enter the project name: "
if not defined projectName (
    echo Project name is required!
    goto :prompt
)

echo.
set /p "newProjectDir=Enter the new project directory: "
if not defined newProjectDir (
    echo New project directory is required!
    goto :prompt
)

echo.
echo Creating project, please wait...

powershell.exe -ExecutionPolicy Bypass -File "Scaffold.ps1" -ProjectName "%projectName%" -NewProjectDir "%newProjectDir%"

pause