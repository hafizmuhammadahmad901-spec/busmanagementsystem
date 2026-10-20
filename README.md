🚌 Bus Ticket Management System
[![.NET Version](https://img.shields.io/badge/.NET-10.0-purple.svg)](https://dotnet.microsoft.com/)
[![Language](https://img.shields.io/badge/Language-C%23-blue.svg)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Architecture](https://img.shields.io/badge/Architecture-3--Tier%20Layered-orange.svg)](#-architecture--design-pattern)
[![Status](https://img.shields.io/badge/Status-Completed-success.svg)]()
A robust, console-based **Bus Ticket Management System** developed in **C# (.NET)**. The project strictly implements **Object-Oriented Programming (OOP)** principles and follows a clean **3-Tier / Layered Architecture** (Presentation, Business Logic, and Data Access / Repository layers) with persistent file storage.
---
## 📑 Table of Contents
- [✨ Key Features](#-key-features)
- [🏗️ Architecture & Design Pattern](#️-architecture--design-pattern)
- [📂 Project Structure](#-project-structure)
- [🧩 OOP Principles Implemented](#-oop-principles-implemented)
- [🔑 Default Credentials](#-default-credentials)
- [🚀 Getting Started](#-getting-started)
- [💾 Data Persistence](#-data-persistence)
- [🔮 Future Enhancements](#-future-enhancements)
---
## ✨ Key Features
### 1. 🛡️ Role-Based Access Control (RBAC)
- **Admin Portal:**
  - View all buses and their detailed specifications.
  - Add new buses (with real-time Bus ID and capacity validation).
  - View all booked tickets across the entire fleet.
- **Manager Portal:**
  - View active buses and schedules.
  - Dynamically update bus fares.
  - View comprehensive booking logs.
- **Customer Portal:**
  - Secure User Sign-up & Login authentication.
    ## 🏗️ Architecture & Design Pattern
The project is structured according to the **3-Tier (N-Layered) Software Architecture** to ensure high maintainability, testability, and separation of concerns:
```
[ User Interaction / Terminal ]
             │
             ▼
┌───────────────────────────────────────────┐
│        Presentation Layer (UI)            │  <-- Program.cs (Menus & User I/O)
└─────────────────────┬─────────────────────┘
                      │ DTOs / Models
                      ▼
┌───────────────────────────────────────────┐
│     Business Logic Layer (Services)       │  <-- CustomerService, AdminService, ManagerService
└─────────────────────┬─────────────────────┘
                      │
                      ▼
┌───────────────────────────────────────────┐
│       Data Access Layer (Repository)      │  <-- BusRepository, TicketRepository, CustomerRepository
└─────────────────────┬─────────────────────┘
                      │ File I/O
                      ▼
┌───────────────────────────────────────────┐
│       Persistent Storage (.txt Files)     │  <-- buses.txt, tickets.txt, customers.txt
└───────────────────────────────────────────┘
```
---
## 📂 Project Structure
```bash
BusTicketManagementSystem/
│
├── MODEL/                         # Domain Entities (Data Holders)
│   ├── Admin.cs
│   ├── Bus.cs
│   ├── Customer.cs
│   ├── Manager.cs
│   └── Ticket.cs
│
├── REPOSITORY/                    # Data Access Layer (File Persistence)
│   ├── BusRepository.cs
│   ├── CustomerRepository.cs
│   └── TicketRepository.cs
│
├── BUISNESS/                      # Business Logic Layer (Services & Validation)
│   ├── AdminService.cs
│   ├── BusService.cs
│   ├── CustomerService.cs
│   ├── ManagerService.cs
│   └── TicketService.cs
│
├── Program.cs                     # Presentation Layer (Console Menu System)
├── BusTicketManagementSystem.csproj
└── README.md
```
---
  - Browse available buses, routes, and fare pricing.
  - Real-time seat reservation with duplicate seat booking prevention.
  - View personal booked tickets history
    ## 🧩 OOP Principles Implemented
- **Encapsulation:** All model properties are encapsulated with getters and setters, ensuring data integrity.
- **Constructor Overloading:** Every model class implements:
  - *Default Constructor* (for empty initialization)
  - *Parameterized Constructor* (for complete object instantiation)
  - *Copy Constructor* (for deep/independent object replication)
- **Separation of Concerns (SoC):** Database/file operations are completely decoupled from UI and business logic.
- **Dependency Injection (Constructor Injection):** Repositories are injected into services through constructors, ensuring loose coupling and testability.
---
## 🔑 Default Credentials
For quick testing during evaluations or demos:
| Role | Username | Password |
| :--- | :--- | :--- |
| **Admin** | `admin` | `admin1234` |
| **Manager** | `manager` | `manager1234` |
| **Customer** | *(Sign up as a new user through menu)* | *(Your password)* |
---
## 🚀 Getting Started
### Prerequisites
- [.NET SDK 8.0, 9.0, or 10.0](https://dotnet.microsoft.com/download) installed on your system.
### Installation & Execution
1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/BusTicketManagementSystem.git
   cd BusTicketManagementSystem
   ```
2. **Build the application:**
   ```bash
   dotnet build
   ```
3. **Run the application:**
   ```bash
   dotnet run
   ```
---
## 💾 Data Persistence
All data is automatically loaded from and saved to persistent text files:
- `buses.txt`: Stores fleet configuration (Bus ID, Name, Source, Destination, Fare, Total Seats).
- `customers.txt`: Stores registered customer credentials.
- `tickets.txt`: Stores booking details (Ticket ID, Bus ID, Customer Name, Seat Number, Fare).
---
## 🔮 Future Enhancements
- [ ] Migrate file storage to a Relational Database (SQL Server / PostgreSQL with Entity Framework Core).
- [ ] Build a Modern GUI (WPF or ASP.NET Core Web API + React).
- [ ] Add Online Payment Gateway integration.
- [ ] Implement PDF ticket generation with QR code verification.
---
## 👤 Author
Developed with  by HAFIZ MUHAMMAD AHMAD  
- GitHub: https://github.com/hafizmuhammadahmad901-spec/busmanagementsystem  
- LinkedIn: https://www.linkedin.com/in/hafiz-muhammad-ahmad-a713673b7/
