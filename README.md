🏥 Hospital Management System

A modular **ASP.NET Core Hospital Management System** built with **Clean Architecture**, **CQRS**, **MediatR**, **Dapper**, **SQL Server**, **JWT Authentication**, and **ASP.NET Core MVC**.

The project is designed to demonstrate how to build a maintainable, secure, and scalable enterprise-style .NET application.

---

## 🚀 Tech Stack

* **.NET 10**
* **ASP.NET Core Web API**
* **ASP.NET Core MVC**
* **C#**
* **SQL Server**
* **Dapper**
* **CQRS**
* **MediatR**
* **Clean Architecture**
* **Repository Pattern**
* **Dependency Injection**
* **JWT Bearer Authentication**
* **BCrypt Password Hashing**
* **ASP.NET Core Authorization**
* **ASP.NET Core Data Protection**
* **Swagger / OpenAPI**
* **CORS**
* **HSTS / HTTPS**
* **Async / Await**
---

# 🏗️ Architecture

The project follows **Clean Architecture** with clear separation between the Domain, Application, Infrastructure, and API layers.

```text
┌──────────────────────────────┐
│        MVC Web App           │
│ HospitalManagementSystemWeb  │
└──────────────┬───────────────┘
               │ HTTP
               ▼
┌──────────────────────────────┐
│           API                │
│ Controllers / Middleware     │
│ JWT / Authorization / Swagger│
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│       Application            │
│ CQRS / MediatR / DTOs        │
│ Commands / Queries / Handlers│
│ Repository Interfaces        │
└──────────────┬───────────────┘
               │
               ▼
┌──────────────────────────────┐
│          Domain              │
│ Entities / Constants         │
└──────────────────────────────┘

┌──────────────────────────────┐
│       Infrastructure         │
│ Dapper / SQL Server          │
│ Repositories / Security      │
│ JWT / BCrypt / DI            │
└──────────────────────────────┘
```

### Dependency Direction

API
 ├── Application
 └── Infrastructure

Application
 └── Domain

Infrastructure
 ├── Application
 └── Domain

Infrastructure implements the interfaces defined by Application.

The API acts as the **Composition Root**, where dependencies are registered and the application is assembled.

---

# 📂 Solution Structure

HospitalManagementSystem/
│
├── HospitalManagementSystem/
│   ├── Controllers/
│   ├── Middleware/
│   ├── Extensions/
│   ├── Program.cs
│   └── appsettings.json
│
├── HospitalManagementSystem.Application/
│   ├── Patients/
│   ├── Doctors/
│   ├── Departments/
│   ├── Appointments/
│   ├── Authentication/
│   ├── Users/
│   └── Interfaces/
│
├── HospitalManagementSystem.Domain/
│   ├── Entities/
│   └── Constants/
│
├── HospitalManagementSystem.Infrastructure/
│   ├── DataAccess/
│   │   ├── ConnectionFactory/
│   │   └── Dapper/
│   ├── DependencyInjection/
│   └── Security/
│       ├── PasswordHasher/
│       ├── Policies/
│       └── TokenService/
│
├── HospitalManagementSystemWeb/
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   ├── Views/
│   └── wwwroot/ --> Js files , css file
│
├── HospitalManagementSystem.UnitTests/
│
├── HospitalManagementSystem.IntegrationTests/
│
├── DataBase/
│   └── HospitalManagementSystem_DBScripts.sql
│
└── HospitalManagementSystem.slnx

---

# 🧩 Main Modules

The system currently contains the following major modules:

* 👤 Authentication
* 👨‍⚕️ Doctors
* 🧑‍🤝‍🧑 Patients
* 🏢 Departments
* 📅 Appointments
* 👨‍💼 Admin
* 👥 Users

Each feature follows the same general application pattern:

```text
Command / Query
       ↓
    Handler
       ↓
Repository Interface
       ↓
Repository Implementation
       ↓
     Dapper
       ↓
   SQL Server
```

---

# 🔄 CQRS + MediatR

The project uses **CQRS** to separate read and write operations.

### Commands

Commands change application state:

```text
CreatePatientCommand
UpdatePatientCommand
DeletePatientCommand
```

### Queries

Queries read data:

```text
GetPatientByIdQuery
GetAllPatientsQuery
SearchPatientsQuery
```

MediatR dispatches these requests to their corresponding handlers.

Example:

```text
HTTP Request
     ↓
Controller
     ↓
MediatR
     ↓
Handler
     ↓
Repository
     ↓
SQL Server
```

---

# 🗄️ Database (ORM)

The project uses **SQL Server** with **Dapper** for data access.

The database can be created using the SQL script located at:

```text
DataBase/HospitalManagementSystem_DBScripts.sql
```

No Entity Framework migrations are required.

---

# 🔐 Security

The project implements several security mechanisms:

### JWT Authentication

Used to authenticate API users.

```text
Login
  ↓
Validate credentials
  ↓
Generate JWT
  ↓
Client sends Bearer token
  ↓
API validates token
```

### BCrypt

Passwords are hashed using BCrypt before being stored.

Passwords are **never stored as plain text**.

### Authorization

Authorization policies/roles are used to control access to protected endpoints.

### Data Protection

ASP.NET Core Data Protection is registered for protecting application/framework data that requires authenticated encryption.

### HTTPS + HSTS

The application uses HTTPS and HSTS to improve transport security.

### CORS

CORS is configured to allow the MVC application to communicate with the API from the configured origin.

### Exception Middleware

Unhandled exceptions are handled centrally through middleware instead of duplicating exception handling in every controller.

---

# ⚙️ Getting Started

## Prerequisites

Install:

* [.NET 10 SDK](https://dotnet.microsoft.com/)
* SQL Server
* SQL Server Management Studio (SSMS)
* Git
* Visual Studio or VS Code

---

## 1. Clone the Repository

```bash
git clone https://github.com/Ahmad-AlBanna/HospitalManagementSystem.git

cd HospitalManagementSystem
```

---

## 2. Restore Dependencies

```bash
dotnet restore
```

---

## 3. Build the Solution

```bash
dotnet build
```

---

## 4. Create the Database

Open SQL Server Management Studio.

Open:

```text
DataBase/HospitalManagementSystem_DBScripts.sql
```

Execute the script against your SQL Server instance.

Then verify that the database and tables were created.

---

## 5. Configure the Connection String

Update the connection string in the API configuration.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=HospitalManagementSystem;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Adjust the server/instance name according to your local SQL Server installation.

> Do not commit real production passwords or secrets to GitHub.

---

## 6. Run the API

```bash
dotnet run --project HospitalManagementSystem/HospitalManagementSystem.API.csproj
```

The API will start on its configured HTTPS URL.

Open Swagger from the URL shown in the console.

---

## 7. Run the MVC Web Application

In another terminal:

```bash
dotnet run --project HospitalManagementSystemWeb/HospitalManagementSystemWeb.csproj
```

The MVC application communicates with the API.

---

# 🧪 Testing the API

You can test the API using:

* Swagger
* Postman
* `HospitalManagementSystem.http`

Recommended testing flow:

```text
1. Login / Register --> login for Admin email :- admin@hospital.com \ Pass  :- Admin@123
       ↓
2. Get JWT
       ↓
3. Authorize Swagger/Postman
       ↓
4. Create Department
       ↓
5. Create Doctor
       ↓
6. Create Patient
       ↓
7. Create Appointment
       ↓
8. Get / Search records
       ↓
9. Update records
       ↓
10. Delete test records
```

For protected endpoints:

```http
Authorization: Bearer <YOUR_JWT>
```

---

# 🧪 Running Tests

Run the test projects with:

```bash
dotnet test
```

The solution contains:

```text
HospitalManagementSystem.UnitTests
HospitalManagementSystem.IntegrationTests
```

---

# 🔍 Example Request Flow

For:

```http
POST /api/patients
```

the request travels through the application like this:

```text
Client
  ↓
PatientsController
  ↓
CreatePatientCommand
  ↓
MediatR
  ↓
CreatePatientCommandHandler
  ↓
IPatientRepository
  ↓
PatientRepository
  ↓
Dapper
  ↓
SQL Server
```

This keeps controllers thin and separates HTTP, application logic, and persistence.

---

# 🎯 Architectural Goals

The project was designed around these principles:

* **Separation of Concerns**
* **SOLID Principles**
* **Dependency Inversion**
* **Clean Architecture**
* **CQRS**
* **Thin Controllers**
* **Testability**
* **Maintainability**
* **Secure-by-design development**
* **Explicit SQL through Dapper**
* **Feature-oriented organization**

The main architectural rule is:

> **Business/application logic should not depend on infrastructure details.**

For example:

```text
Application
     ↓
IPatientRepository
     ↑
PatientRepository
     ↓
Dapper
     ↓
SQL Server
```

The Application layer only knows about the repository abstraction. It does not need to know that Dapper or SQL Server is being used.

---

# 📚 What This Project Demonstrates

This project demonstrates practical implementation of:

* ASP.NET Core Web API
* ASP.NET Core MVC
* Clean Architecture
* CQRS
* MediatR
* Dapper
* SQL Server
* Repository Pattern
* Dependency Injection
* SOLID Principles
* JWT Authentication
* Authorization Policies
* BCrypt Password Hashing
* ASP.NET Core Data Protection
* Middleware
* CORS
* HSTS
* HTTPS
* Swagger/OpenAPI
* Async/Await
* Unit Testing Foundation
* Integration Testing Foundation

---

# 👨‍💻 Author

**Ahmad AlBanna**

GitHub:
https://github.com/Ahmad-AlBanna

---

## ⭐ If You Find This Project Useful

Feel free to fork the repository, explore the architecture, and use it as a reference for learning modern ASP.NET Core application development.
