@echo off
title Asset Management - FULL AUTO Setup

echo =====================================
echo   Asset Management FULL AUTO Setup
echo =====================================

cd /d %~dp0

REM ==============================
REM Admin Check
REM ==============================
net session >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo Please run this file as Administrator.
    pause
    exit /b
)

REM ==============================
REM Install Chocolatey
REM ==============================
where choco >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo Installing Chocolatey...
    powershell -NoProfile -ExecutionPolicy Bypass -Command ^
     "Set-ExecutionPolicy Bypass -Scope Process -Force; ^
      [System.Net.ServicePointManager]::SecurityProtocol = 3072; ^
      iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))"
)

REM ==============================
REM Install .NET SDK
REM ==============================
dotnet --version >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo Installing .NET SDK...
    choco install dotnet-sdk -y
)

REM ==============================
REM Install Node.js
REM ==============================
node --version >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo Installing Node.js...
    choco install nodejs-lts -y
)

REM ==============================
REM Install Angular CLI
REM ==============================
ng version >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo Installing Angular CLI...
    npm install -g @angular/cli
)

REM ==============================
REM Install dotnet-ef
REM ==============================
dotnet ef --version >nul 2>&1
if %ERRORLEVEL% neq 0 (
    echo Installing dotnet-ef...
    dotnet tool install --global dotnet-ef
)

REM ==============================
REM Refresh Path
REM ==============================
refreshenv

REM ==============================
REM Restore Backend
REM ==============================
echo.
echo Restoring Backend...
cd AssetManagement.API
dotnet restore

REM ==============================
REM Update Database
REM ==============================
echo.
echo Updating Database...
dotnet ef database update

if %ERRORLEVEL% neq 0 (
    echo Database Migration Failed!
    pause
    exit /b
)

REM ==============================
REM Run Backend
REM ==============================
start "Backend API" cmd /k "dotnet run"

cd /d %~dp0

REM ==============================
REM Install Frontend
REM ==============================
cd AssetManagement.Ui
npm install

REM ==============================
REM Run Frontend
REM ==============================
start "Angular App" cmd /k "ng serve"

REM ==============================
REM Wait
REM ==============================
timeout /t 20 /nobreak >nul

REM ==============================
REM Open Browser
REM ==============================
start http://localhost:4200

echo.
echo =====================================
echo   Setup Completed Successfully
echo =====================================

pause
