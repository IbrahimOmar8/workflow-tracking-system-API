# ✅ Workflow Tracking System

This project is a Workflow and Process Tracking System** that allows organizations to define, execute, and monitor multi-step workflows. Developed with **.NET 7 Web API** and an **Angular 18 Admin Dashboard**.

---

## ✨ Features

- Define and manage workflows with multiple steps
- Assign tasks to different user roles (employee, manager, finance)
- Execute steps with input, approval, or rejection logic
- Built-in validation middleware simulating external API checks
- Admin dashboard with real-time workflow tracking

---

## 🚀 Tech Stack

- 🔧 .NET 7 Web API + Entity Framework Core
- 🎨 Angular 18 (Standalone API) + Angular Material
- 🧠 SQLite (local database)
- 🧪 Swagger UI for interactive API documentation

---

## 📦 API Endpoints

| Endpoint                          | Method | Description                   |
|----------------------------------|--------|-------------------------------|
| `/v1/workflows`                  | POST   | Create a new workflow         |
| `/v1/workflows/{id}`             | PUT    | Update an existing workflow   |
| `/v1/workflows`                  | get    | Get all workflows             |
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

/backend
  ├── Application
  │   ├── Interfaces
  │   ├── Services
  │   └── DTOs
  ├── Domain
  │   ├── Entities
  │   ├── ValueObjects
  │   └── Interfaces
  ├── Infrastructure
  │   ├── Data
  │   ├── Repositories
  │   └── Migrations
  ├── Presentation
  │   ├── Controllers
  │   └── Middleware
  └── Tests
      ├── UnitTests
      └── IntegrationTests
