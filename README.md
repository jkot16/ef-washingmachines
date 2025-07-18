# 🧼 Washing Machine API (APBD Test 2)

REST API for managing washing machines and customer purchases using **ASP.NET Core** and **EF Core** with a **Code First** approach.

## 🚀 Overview

This project demonstrates:
- Adding a washing machine with available programs
- Fetching a customer’s full purchase history

## 🛠️ Tech Stack

- ASP.NET Core 8  
- EF Core (Code First)  
- SQL Server  
- Swagger UI  

## ✨ Key Features

- `POST /api/washing-machines`  
→ Adds a new machine with its programs

- `GET /api/customers/{id}/purchases`  
→ Returns a customer's purchase history

## 📁 Folder Structure

- `Controllers/` – API endpoints  
- `Services/` – Business logic  
- `Contracts/` – DTOs for requests/responses  
- `Data/DBContext.cs` – EF configuration  
- `appsettings.json` – DB config  

---

Built as part of an academic assignment to demonstrate full-stack API development using EF Core.
