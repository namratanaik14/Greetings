
# Greetings API

An ASP.NET Core Web API project that provides greeting messages via RESTful endpoints. The project integrates Entity Framework Core for database operations, MemoryCache for caching, and rate limiting.

## Features

- Create, read, and manage greeting messages.
- Entity Framework Core integration for data persistence.
- In-memory caching with `IMemoryCache`.
- Rate limiting to control API request load.
- Async/await API handling.
- Includes sample HTTP request files (`Greetings.http`).

## Tech Stack

- **ASP.NET Core 8.0**
- **Entity Framework Core**
- **In-Memory Cache**
- **SQLite (or your configured database)**
- **.NET CLI / Visual Studio**

## Project Structure

```
Greetings.sln
└── Greetings/
    ├── Controllers/
    │   └── Greeting.cs
    ├── Data/
    │   └── GreetingContext.cs
    ├── Migrations/
    ├── Models/
    │   └── IGreetingRepository.cs
    │   └── GreetingRepository.cs
    ├── Program.cs
    ├── appsettings.json
    ├── appsettings.Development.json
    └── Greetings.http
```

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQLite (or configure another database provider in `Program.cs` and `appsettings.json`)

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/namratanaik14/Greetings.git
   cd Greetings
   ```

2. **Restore dependencies**

   ```bash
   dotnet restore
   ```

3. **Apply database migrations**

   ```bash
   dotnet ef database update
   ```

4. **Run the application**

   ```bash
   dotnet run --project Greetings
   ```

## API Endpoints

| Method | Endpoint             | Description                        |
|:--------|:---------------------|:------------------------------------|
| `GET`   | `/api/greeting`       | Get greetings                  |
| `POST`  | `/api/greeting`       | Add a new greeting                  |

### Example GET Request

```http
GET https://localhost:{port}/api/greeting?name=John
Content-Type: application/json
```

### Example POST Request

```http
POST https://localhost:{port}/api/greeting
Content-Type: application/json

{
  "John"
}
```

## Caching & Rate Limiting

- Uses `IMemoryCache` to cache frequently accessed greeting data for improved response times.
- Rate limiting can be configured via middleware to control request bursts.

## Notes

- Modify `appsettings.json` for database connection settings.
- Database migrations are already scaffolded in the `Migrations/` directory.

## License

This project is licensed under the MIT License.
