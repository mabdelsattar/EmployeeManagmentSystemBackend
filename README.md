# 3SEgypt Backend

Minimal ASP.NET Core Web API for Employee CRUD.

To run:

1. Restore and build: `dotnet build` in `3segyptbackend/ThreeSEgypt.API`
2. Apply EF migrations or let EF create DB: ensure connection string in `appsettings.json`.
3. Run: `dotnet run` in `3segyptbackend/ThreeSEgypt.API`

Endpoints:
- `GET /api/employees?search=&page=1&pageSize=10`
- `POST /api/employees`
- `DELETE /api/employees/{id}`
- `GET /api/lookup/departments`
