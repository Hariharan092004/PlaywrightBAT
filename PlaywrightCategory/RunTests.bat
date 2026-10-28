
@echo off
setlocal

echo ========================================
echo   PlaywrightBAT - Test Execution
echo ========================================

cd /d "%~dp0"

dotnet test "PlaywrightCategory.csproj" --logger "trx;LogFileName=TestResults.trx" --results-directory "TestResults"

echo.
echo ========================================
echo   Test execution completed.
echo   Check the TestResults folder.
echo ========================================

pause
