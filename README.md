# Asset Management System

A simple web-based Asset Management System for managing corporate assets such as laptops, monitors, and headphones. Users can view, add, edit, and delete assets efficiently through a web interface.
---

## 🛠️ Tech Stack

### Backend
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / LocalDB

### Frontend
- Angular 20
- PrimeNG
- TypeScript
- RxJS

---

## 📂 Project Structure

```
AssetManagement/
│
├── AssetManagement.API
│   │   ├── Controllers
│   │   ├── Models
│   │   ├── Data
│   │   ├── Services
│   │   ├── Middleware
│   │   └── Program.cs
├── asset-management-ui
├── src/app
│   ├── components
│   ├── services
│   ├── models
│   └── pages
└── environments
```
```
## ⚙️ Prerequisites

- .NET SDK 8+
- Node.js 18+
- Angular CLI
- SQL Server / LocalDB
- Visual Studio / VS Code
```
---

## 🚀 Backend Setup

```bash
cd AssetManagement.API
dotnet ef database update
dotnet run
```

---

## 🌐 Frontend Setup

```bash
cd AssetManagement.Ui
npm install
ng serve
```

---

## 🔗 API Endpoints

### Assets
- GET /api/assets
- GET /api/assets/{id}
- POST /api/assets
- PUT /api/assets/{id}
- DELETE /api/assets/{id}

### Categories
- GET /api/categories

---

## 👨‍💻 Author

Developed by Edokza

---

## 📄 License

Educational and technical assessment purposes.
