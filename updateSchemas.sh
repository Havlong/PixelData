dotnet ef database drop -p app
dotnet ef migrations remove -p app
dotnet ef migrations add InitializeDatabase -p app
dotnet ef database update -p app