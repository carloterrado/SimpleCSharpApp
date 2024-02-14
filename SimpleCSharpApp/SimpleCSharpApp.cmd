@echo off
rem A batch file for SimpleCSharpApp.exe
rem which captures the app's return value.

rem Run SimpleCSharpApp.exe with command-line arguments
dotnet run -- /arg1 -arg

rem Check the return value and display appropriate message
if %ERRORLEVEL% equ 0 (
    echo This application has succeeded!
) else (
    echo This application has failed
)
echo Return value = %ERRORLEVEL%

echo All Done
