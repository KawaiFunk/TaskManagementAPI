Task Management API

A web-based Task Management System built with ASP.NET Core MVC and Entity Framework Core. The system allows users to manage tasks, users, categories, and more. This project includes CRUD operations and supports role-based authorization.

Features

Users

Register Users: Create new users with role-based permissions.

User Login: Authenticate users with secure JWT-based tokens.

Role Management: Admin and User roles with policies for accessing resources.

Update/Delete Users: Modify user details or delete users.

Tasks

Create Tasks: Assign tasks to users with specific priorities, due dates, and statuses.

Update/Delete Tasks: Modify or remove tasks from the system.

View Tasks: List all tasks or filter by user.

Mark as Complete: Update task status to completed.

Assign Categories: Categorize tasks for better organization.

Categories

Create/Update/Delete Categories: Manage task categories.

View Categories: List all available categories.

Authorization

JWT-based authentication with role-based policies for Admin and User roles.

Technologies Used

Framework: ASP.NET Core MVC

Database: Microsoft SQL Server with Entity Framework Core

Authentication: JWT (JSON Web Token)

Dependency Injection: Built-in DI for services and repositories

Security: Password hashing using BCrypt
