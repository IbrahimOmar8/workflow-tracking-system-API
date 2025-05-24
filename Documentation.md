

# 📘 Workflow Tracking System – Project Documentation

---

## 🧰 Technologies Used

- .NET 7 Web API
- Entity Framework Core
- Angular 18 (Standalone Components)
- Angular Material Design
- SQLite (file-based DB for dev)
- Swagger for API testing

---


## ✨ Features

- Define and manage workflows with multiple steps
- Assign tasks to different user roles (employee, manager, finance)
- Execute steps with input, approval, or rejection logic
- Built-in validation middleware simulating external API checks
- Admin dashboard with real-time workflow tracking


## 📦 API Endpoints

| Endpoint                          | Method | Description                   |
|----------------------------------|--------|-------------------------------|
| `/v1/workflows`                  | POST   | Create a new workflow         |
| `/v1/workflows/{id}`             | PUT    | Update an existing workflow   |
| `/v1/processes/start`            | POST   | Start a new workflow process  |
| `/v1/processes/execute`          | POST   | Execute a workflow step       |
| `/v1/processes`                  | GET    | Get list of processes         |
| `/v1/processes/validations`      | GET    | Get list of validations         |

---

## 🔧 Setup Instructions

### 🖥️ Backend (.NET Core)

```bash
cd WorkFlow
dotnet ef database update
dotnet run



Folder Structure

backend/
│
├── Controllers/         # API Controllers
├── DTOs/                # Request/Response Models
├── Data/                # for Db context
├── Models/              # EF Core Entities
├── Interface/           # Interface for services
├── Middleware/          # Validation & Logging
└── Services/            # Business Logic

## 🏁 Backend Setup (ASP.NET Core)

1. **Clone the repository**

```bash
git clone https://github.com/your-repo/workflow-tracking-system.git
cd workflow-tracking-system/backend


Install dependencies and setup DB


dotnet restore
dotnet ef database update

dotnet run







