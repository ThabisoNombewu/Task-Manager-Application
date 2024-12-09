# Task-Manager-Application
# TaskManager Backend

The **TaskManager Backend** is a RESTful API built using .NET Core. It manages tasks and users, enabling operations such as creating, retrieving, updating, and deleting task and user data. It is designed to be integrated with a frontend application or any API client.

---

## Table of Contents
- [Features](#features)
- [Getting Started](#getting-started)
- [API Endpoints](#api-endpoints)
  - [Tasks API](#tasks-api)
  - [Users API](#users-api)
- [References](#references)

---

## Features
- RESTful API for managing **Tasks** and **Users**.
- JSON response format for easy integration.
- SQL Server as the database for secure data storage.
- Data validation and error handling included.
- Scalable architecture ready for deployment.

---

## Getting Started

### Prerequisites
Ensure you have the following installed:
- **.NET Core SDK**: Version 6.0 or later.
- **SQL Server**: Local or hosted.
- **Postman** (optional): For testing APIs.
The API will be accessible at:

http://localhost:5000
https://localhost:5001
API Endpoints

## Tasks API
Manage tasks with the following endpoints:

HTTP Method	Endpoint	Description
GET	/api/tasks	Retrieve all tasks.
GET	/api/tasks/{id}	Retrieve a specific task.
POST	/api/tasks	Create a new task.
PUT	/api/tasks/{id}	Update an existing task.
DELETE	/api/tasks/{id}	Delete a specific task.

## Users API
Manage users with the following endpoints:

HTTP Method	Endpoint	Description
GET	/api/users	Retrieve all users.
GET	/api/users/{id}	Retrieve a specific user.
POST	/api/users	Create a new user.
PUT	/api/users/{id}	Update an existing user.
DELETE	/api/users/{id}	Delete a specific user.

## References

- [Microsoft Docs - .NET Core](https://learn.microsoft.com/en-us/dotnet/core/)
- [Entity Framework Core Documentation](https://learn.microsoft.com/en-us/ef/core/)
- [Postman API Testing](https://www.postman.com/)
- [SQL Server Documentation](https://learn.microsoft.com/en-us/sql/sql-server/)
- [GitHub Documentation - Git Basics](https://docs.github.com/en/get-started/using-git)
- [ASP.NET Core Tutorial](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0)
- [RESTful API Design Guidelines](https://restfulapi.net/)
