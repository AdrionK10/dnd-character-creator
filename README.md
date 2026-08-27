# D&D Character Creator

Teaching template for a full-stack app: Blazor Server UI, ASP.NET Core API, Entity Framework Core + SQLite.

## Projects

| Project | Role |
|---|---|
| `src/CharacterCreator.Web` | UI layer (Blazor Server) |
| `src/CharacterCreator.Api` | API layer (controller + service) |
| `src/CharacterCreator.Data` | Persistence (EF Core `DbContext` + `Character` entity) |

Request path: **Web → HTTP → Api → CharacterService → DbContext → SQLite**.

## Run both apps

From two terminals:

```powershell
dotnet run --project src/CharacterCreator.Api
dotnet run --project src/CharacterCreator.Web
```

- API: `http://localhost:5057` (HTTPS: `https://localhost:7175`)
- UI: `http://localhost:5164` (HTTPS: `https://localhost:7113`)

Local Development uses HTTP so you do not have to trust the ASP.NET HTTPS developer certificate first.

The first API start applies the EF migration and creates `src/CharacterCreator.Api/characters.db`.

## What is already wired

- `Character` entity and `CharacterDbContext`
- SQLite connection string
- `ICharacterService` / `CharacterService` with **read** methods (`GetAll`, `GetById`)
- `GET /api/characters` and `GET /api/characters/{id}`
- Characters page that calls the list endpoint

## Suggested next lessons

1. Add more fields on `Character` (ability scores, background, and so on)
2. Implement create, update, and delete on the service and controller
3. Build a character form in Blazor
4. Add a new migration after each model change:

```powershell
dotnet ef migrations add <Name> --project src/CharacterCreator.Data --startup-project src/CharacterCreator.Api --output-dir Migrations
```
