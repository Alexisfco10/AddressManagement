# Address Management API

A .NET Web API for managing customers and their addresses. Includes full CRUD operations, database migrations, and testing with Postman or `.http` requests.

---

## Requirements

Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Developer or Express)
- A code editor:
   - [Visual Studio 2022+](https://visualstudio.microsoft.com/) with ASP.NET & EF workloads
   - or [JetBrains Rider](https://www.jetbrains.com/rider/)
- [Postman](https://www.postman.com/downloads/) (for API testing)
- Git (if cloning via CLI)

---

## Setup Instructions

1. Clone the repo
2. Add your own `appsettings.json` with your connection string
3. Restore NuGet packages with `dotnet restore`
4. Run the project with `dotnet run`

## Database Setup

1. Set your connection string in `appsettings.Development.json`
2. Open the terminal in the project directory
3. Run the following command to create the database and apply migrations:

```
dotnet ef database update
```

## API Testing

You can test the API using either:

1. `AddressManagement.http` — open in Rider or VS and send requests directly.
   - Change the AddressManagement_HostAddress variable if needed
   - Use valid data in each request

2. Postman:
    - Import `Web/postman/AddressManagement.postman_collection.json`
    - Use environment variables if needed
    - Change the base_url variable if needed
    - Use valid data in each request
