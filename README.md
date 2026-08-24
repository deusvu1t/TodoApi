# TodoApi

A small REST API for managing todo tasks, built with ASP.NET Core as a learning project — full CRUD, EF Core + SQLite persistence, DTOs, and input validation.

## Stack

- ASP.NET Core (.NET 10) — controller-based Web API
- Entity Framework Core + SQLite
- Swashbuckle (Swagger / OpenAPI)

## Endpoints

| Method | Route                        | Description              |
|--------|-------------------------------|---------------------------|
| GET    | `/api/todo`                   | List all todos            |
| GET    | `/api/todo/{id}`              | Get a todo by id          |
| POST   | `/api/todo`                   | Create a todo             |
| PUT    | `/api/todo/{id}`              | Update a todo's title     |
| PATCH  | `/api/todo/{id}/complete`     | Mark a todo as complete   |
| PATCH  | `/api/todo/{id}/incomplete`   | Mark a todo as incomplete |
| DELETE | `/api/todo/{id}`              | Delete a todo             |

## Getting started

```bash
dotnet restore
dotnet tool install --global dotnet-ef   # if not already installed
dotnet ef database update                # creates/updates todo.db
dotnet run
```

Then open the Swagger UI (shown in the terminal output, typically `https://localhost:<port>/swagger`) to try the endpoints interactively.

## Project structure

```
Controllers/    HTTP entry points (TodoController)
Data/           EF Core DbContext
DTOs/           Request/response contracts
Extensions/     Entity -> DTO mapping
Migrations/     EF Core schema history
Models/         Domain entity (TodoItem)
Services/       Business logic / data access (TodoService)
```

## Notes

- `todo.db` is local runtime data and is git-ignored — running `dotnet ef database update` recreates it.
- Built incrementally while learning ASP.NET Core: in-memory storage first, then migrated to EF Core + SQLite, then DTOs/validation.
