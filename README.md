# 🌱 Agri-Energy Connect — Final POE (PROG7311,ST10356556)

A prototype enterprise system that enables farmers, green energy experts, and enthusiasts to collaborate, share resources, and innovate in sustainable agriculture and renewable energy.

---

## 🧱 Tech Stack

- **C#** with **ASP.NET Core 8.0**
- **MVC Architecture** using Razor Pages
- **Entity Framework Core**
- **SQLite** database (`agri_energy.db`)
- Compatible with **Windows 10/11**

---

## 🛠 Setup & Run Instructions

### ✅ Prerequisites:

- Visual Studio 2022 or later
- .NET 8 SDK (⚠️ Not .NET 9)
- Windows 10 or 11

### 🚀 Steps to Run:

1. Clone or download the repository.
2. Open `Agri-Energy Connect.sln` in **Visual Studio**.
3. Make sure `agri_energy.db` is located in the root of the project.
4. Build and run using **IIS Express** or **Kestrel** in Visual Studio.

### 📁 Database File Properties:

- Right-click `agri_energy.db` in Solution Explorer → **Properties**
  - `Build Action`: **Content**
  - `Copy to Output Directory`: **Copy if newer**

---

## 👥 Default Login Credentials

### 🧑‍🌾 Farmer
- **Email**: `FarmerEmail_1@gmail.com`
- **Password**: `FarmerPassword_1`

### 🧑‍💼 Employee
- **Email**: `EmployeeEmail@gmail.com`
- **Password**: `EmployeePassword`

---

## 🗃 Database Notes

- The application uses SQLite for local data storage.
- `agri_energy.db` is pre-populated with tables and sample users.
- No internet or external database is required to run the project.
- Accessible immediately upon project launch.

---

## 📄 Project Structure

- `Models/` — Contains `Farmer`, `Employee`, and `Product` entity classes
- `Controllers/` — MVC controllers for managing business logic and view rendering
- `Views/` — Razor Pages for each user role and function
- `Data/ApplicationDbContext.cs` — Entity Framework database context

---

## 🔗 Development Environment

This project was developed and tested using:

- **Visual Studio 2022 (or later)**
- Target Framework: **.NET 8.0**
- Platform: **Windows 10/11**
- Local database: **SQLite**

> ✅ Always run the application using **Visual Studio**.  
> 🚫 Running the project outside of Visual Studio may lead to build or runtime issues due to environment configuration.
>
