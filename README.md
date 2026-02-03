# 📦 Asset Management System

A web-based Asset Management System for managing corporate assets.\
Built with **.NET + Angular**.

------------------------------------------------------------------------

## 🚀 Features

### Backend (.NET + EF Core)

-   CRUD Assets
-   Category Management
-   RESTful API
-   EF Core Migrations
-   Validation
-   Global Error Handling

### Frontend (Angular + PrimeNG)

-   Data Table
-   Asset Form
-   Category Dropdown
-   Reactive Forms
-   Toast Notification

------------------------------------------------------------------------

## 🛠 Tech Stack

### Backend

-   .NET 8+
-   ASP.NET Core Web API
-   Entity Framework Core
-   SQL Server

### Frontend

-   Angular 20
-   PrimeNG
-   TypeScript

------------------------------------------------------------------------

## 📋 Prerequisites

Before running this project, make sure you have installed:

### ✅ Required Software

  Software      Version
  ------------- -------------------
  Git           Latest
  .NET SDK      8+
  Node.js       18+
  Angular CLI   Latest
  SQL Server    Express / LocalDB

------------------------------------------------------------------------

## 🔍 Check Versions

``` bash
git --version
dotnet --version
node --version
ng version
```

------------------------------------------------------------------------

## 📥 Clone Repository

``` bash
git clone https://github.com/Edokza/AssetManagement.git
cd AssetManagement
```

------------------------------------------------------------------------

## ⚙️ Backend Setup (.NET API)

### 1. Go to Backend Folder

``` bash
cd AssetManagement.API
```

------------------------------------------------------------------------

### 2. Install EF Tool (If Not Installed)

``` bash
dotnet tool install --global dotnet-ef
```

------------------------------------------------------------------------

### 3. Create Database

``` bash
dotnet ef database update
```

------------------------------------------------------------------------

### 4. Run Backend

``` bash
dotnet run
```

Backend will run at:

    https://localhost:7078

------------------------------------------------------------------------

## 💻 Frontend Setup (Angular)

### 1. Go to Frontend Folder

``` bash
cd frontend/AssetManagement.Ui
```

------------------------------------------------------------------------

### 2. Install Dependencies

``` bash
npm install
```

------------------------------------------------------------------------

### 3. Run Frontend

``` bash
ng serve
```

Open browser at:

    http://localhost:4200

------------------------------------------------------------------------

## 🧪 How to Use

1.  Run Backend using `dotnet run`
2.  Run Frontend using `ng serve`
3.  Open `localhost:4200`
4.  Add / Edit / Delete Assets
5.  Check data in SQL Server

------------------------------------------------------------------------

## 🔗 API Endpoints

### Assets

  Method   Endpoint
  -------- ------------------
  GET      /api/assets
  POST     /api/assets
  PUT      /api/assets/{id}
  DELETE   /api/assets/{id}

### Categories

  Method   Endpoint
  -------- -----------------
  GET      /api/categories

------------------------------------------------------------------------

## ⚠️ Troubleshooting

### ❌ Cannot Connect to Database

-   Check Connection String
-   Make sure SQL Server is running
-   Verify Server Name

### ❌ npm Install Error

``` bash
npm cache clean --force
rm -rf node_modules
npm install
```
------------------------------------------------------------------------

## 👤 Author

Edokza

------------------------------------------------------------------------

## 📄 License

For Educational Purpose Only
