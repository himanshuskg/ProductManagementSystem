# Product Management System

A **Product Management System** built using **ASP.NET Core MVC** following a **layered architecture** approach.  
The application is designed to manage products and categories efficiently while maintaining clean separation of concerns across layers.

---
## 📘 Project Overview

This project demonstrates the implementation of a structured ASP.NET Core MVC application using separate layers for presentation, business logic, data access, and domain models. It focuses on maintainability, scalability, and clean backend design.

---
## 🚀 Features

- Product management (Create, Read, Update, Delete)
- Category management
- Server-side validation
- Clean separation of concerns using layered architecture
- Repository and service-based design
- User-friendly MVC-based UI

---
## 🛠️ Tech Stack

- **Framework:** ASP.NET Core MVC (.NET 8)
- **Frontend:** Razor Views, HTML, CSS, JavaScript, Bootstrap, Kendo UI (Open-source NuGet packages)
- **Backend:** C#
- **Database:** SQL Server
- **ORM:** Entity Framework Core
- **IDE:** Visual Studio 2022
- **Version Control:** Git & GitHub
  
---
## 📂 Project Structure (Layered Architecture)

The solution is organized into multiple projects to maintain a clean and scalable architecture.

ProductManagementSystem (MVC Web Application)
|
ProductManagementSystem.DOMAIN (Domain Layer)
│ 
ProductManagementSystem.DAL (Data Access Layer)
│ 
ProductManagementSystem.BAL (Business Access Layer)

---
## 🧠 Architecture Overview

- **MVC Web Project:** Handles UI, HTTP requests, and responses.
- **Domain Layer:** Contains core business entities and models.
- **DAL (Data Access Layer):** Manages database operations using Entity Framework Core.
- **BAL (Business Access Layer):** Contains business rules and service logic.

This layered approach improves maintainability, scalability, and testability.

---
## ⚙️ Setup & Run

1. Clone the repository:
   ```bash
   git clone https://github.com/himanshuskg/ProductManagementSystem.git
2. Open the solution file ProductManagementSystem.sln in Visual Studio 2022

3. Configure the SQL Server connection string in appsettings.json

4. Apply database migrations:
Update-Database

5.Run the application using IIS Express or Kestrel
-Ensure SQL Server is running before applying migrations.

---
## 👨‍💻 Author
**Himanshu Sahu**  
Software Developer
---

## 📄 License

This project is intended for learning and assignment purposes.
