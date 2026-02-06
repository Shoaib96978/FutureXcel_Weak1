# 🚀 FutureXcel – Full Stack Project Skeleton (Week 1)

## 📌 Overview

This repository contains **Week 1 implementation** of a full-stack project focused on setting up a **clean project skeleton, environment configuration, and basic connectivity** between **frontend, backend, and database**.

The main objective of this week was to initialize a **scalable full-stack foundation** that can be extended in future development phases.

---

## 🧩 Solution Structure

The solution was created using a **Blank Solution template**, then organized into **separate frontend and backend folders** to maintain clear separation of concerns.

## ⚙️ Tech Stack

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- Microsoft SQL Server
- Service-based architecture

### Frontend
- Blazor Server
- Bootstrap 5
- Bootstrap Icons
- Custom CSS (Glassmorphism & animations)

### Database
- Microsoft SQL Server
- EF Core DbContext
- Connection verified through health check

---

## ✅ Week 1 Task Mapping

| Requirement | Status | Implementation |
|------------|--------|----------------|
| Separate frontend & backend folders | ✅ Completed | Frontend & Backend folders |
| Backend health endpoint | ✅ Completed | `GET /api/Health/health` |
| Frontend skeleton | ✅ Completed | Blazor Server UI |
| API call from frontend | ✅ Completed | HttpClient → Health API |
| Database connection | ✅ Completed | EF Core + SQL Server |
| Test database access | ✅ Completed | DB connection open/close |
| .env example | ✅ Completed | `.env.example` included |
| README setup guide | ✅ Completed | This document |

> **Note:**  
> The task mentioned Node.js/Flask, however ASP.NET Core Web API fulfills the same requirement by providing a backend service with a health endpoint and database connectivity.

---

## 🩺 Health Check API

### Endpoint



### Purpose
- Confirms backend availability
- Validates SQL Server database connectivity
- Returns a structured API response

### Sample Response
```json
{
  "data": "Healthy",
  "isSuccess": true,
  "message": "Database Reached Successfully!",
  "status": 200
}

