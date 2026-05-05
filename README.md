#  Patrimony Management
![Status](https://img.shields.io/badge/Status-In%20Development-yellow)
![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![Architecture](https://img.shields.io/badge/Architecture-Layered-green)
![CI/CD](https://img.shields.io/badge/CI/CD-Enabled-success)
![License](https://img.shields.io/badge/License-MIT-lightgrey)

A system developed at **SENAI Informática** to support patrimony (asset) management processes. This project focuses on organizing, tracking, and maintaining institutional assets through a structured and scalable backend API.

---

##  Project Overview

**Patrimony Management** is designed to help organizations control their assets efficiently, offering a centralized system for registering, categorizing, and monitoring patrimonial items.

This project also serves as a practical implementation of modern backend development concepts using **ASP.NET Core**, clean architecture principles, and relational database modeling.

---

##  Project Roadmap

- [X] **Backend API Structure:** Layered architecture implemented  
- [x] **Database Modeling:** Core entities and relationships created  
- [x] **CI/CD Pipeline:** Automated build, analysis, and deployment  
- [x] **Cloud Deployment:** Application deployed and running  
- [ ] **Authentication & Authorization:** Security layer improvements  
      
---

##  Tech Stack

### Backend
- **Language/Framework:** ASP.NET Core 8.0  
- **Architecture:** Layered Architecture (Controllers, Services, Data)  
- **Database:** SQL Server  
- **ORM:** Entity Framework Core  

### DevOps & Tools
- **CI/CD:** GitHub Actions  
- **Code Analysis:** CodeQL  
- **Deployment:** Azure
---

##  Core Features (Planned & In Progress)

- 📦 **Asset Management:** Register and manage patrimony items  
- 🏷️ **Categorization:** Organize assets by type or category  
- 📍 **Location Tracking:** Assign assets to specific locations  
- 👤 **User Control:** Manage system users and permissions  
- 🔐 **Security:** Role-based access control (RBAC)  
- 📊 **Scalability:** Designed for future integrations and growth  

---

##  API Documentation

The API is live and publicly available on Azure:

🔗 Swagger UI:  
https://patrimony-management-c6anfyhnayasckez.canadacentral-01.azurewebsites.net/swagger

> ⚠️ Some endpoints may be incomplete or subject to change.

---

##  How to Run

### Prerequisites

- .NET 8.0 SDK or higher  
- SQL Server (LocalDB, Docker, or full instance)  

---

### Setup Instructions

1. **Clone the repository**
```bash
git clone https://github.com/Rafael-Nunes18/Patrimony-Management.git
cd Patrimony-Management
 ```

2. **Configure the database:**
   - Update your connection string in `appsettings.json` to point to your local SQL Server instance.
  
3. **Apply database migrations:**
   ```bash
   cd Patrimony-Management.API
   dotnet ef database update
   ```

   
4. **Run the API:**
   ```bash
   dotnet run
   ```
