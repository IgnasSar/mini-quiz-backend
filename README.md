# ASP.NET Core Web API

This API was made to manage quiz users and questions.  
It provides endpoints for creating, retrieving, updating, and deleting quiz data such as users and questions.

---

## Technologies Used

This backend project is built using modern Microsoft technologies and tools:

- **.NET 8 / ASP.NET Core Web API** — provides a fast, cross-platform framework for building RESTful APIs.
- **Entity Framework Core** — used as the Object-Relational Mapper (ORM) to interact with the database.
- **SQL Server** — serves as the relational database for storing users, questions, and other quiz-related data.
- **Swagger** — auto-generates API documentation and allows for easy testing through a web interface.
- **C#** — the main programming language used for the application’s logic and structure.

Optional:
- **Dependency Injection** — used to manage repositories and services cleanly.
- **Repository & Service Layers** — improve code organization and maintainability by separating business logic and database operations.

---

## How to Start?

First of all, clone the repository into your desired folder:

```bash
git clone https://github.com/IgnasSar/mini-quiz-backend.git
```

Once that is done, be sure to open package manager console in VS
and update the database:

```
Update-Database
```

Now open the terminal in the root of the folder and start the project:

```
dotnet run --project .\MiniQuizBackend\MiniQuizBackend.csproj
```
