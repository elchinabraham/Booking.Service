🏡 Booking API

A .NET 8 Web API built with Clean Architecture and Domain Driven Design (DDD) principles.
The API allows users to query homes available during a given date range based on pre-defined availability slots stored in memory.

📌 Objective

The goal of this project is to provide a high-performance, scalable, and testable Booking API that:

Returns available homes for a given startDate–endDate range.

Ensures a home is returned only if every date in that range exists in its available slots.

Uses in-memory storage (no database) for simplicity.

Demonstrates best practices such as Clean Architecture, DDD, and asynchronous programming.

🚀 Features

.NET 8 Web API with GET /api/availablehomes

Clean Architecture + DDD Pattern (Domain, Application, Infrastructure, API layers)

Result Pattern for consistent API responses

Dependency Injection / Inversion of Control for extensibility

FluentValidation for input validation

Global Exception Handling for unified error responses

Structured Logging with Serilog

AutoMapper for clean mapping between Entities and DTOs

In-memory Context for storing home availability slots

Asynchronous Filtering for non-blocking performance

Integration Tests with xUnit, FluentAssertions, and WebApplicationFactory

📂 Architecture
BookingApi/
│
├── BookingApi.Api/            # API layer (Controllers, Program.cs, Startup configs)
├── BookingApi.Application/    # Application layer (Services, DTOs, Interfaces, Mappings)
├── BookingApi.Domain/         # Domain layer (Entities, Aggregates, Core logic)
├── BookingApi.Infrastructure/ # Infrastructure layer (Repositories, In-memory context)
└── BookingApi.IntegrationTests/ # Integration tests (xUnit, FluentAssertions)


Layered responsibilities:

Domain → business rules (Home, IsAvailable logic)

Application → service layer, DTOs, mapping, business orchestration

Infrastructure → in-memory repository, data access abstraction

API → controllers, request/response handling, exception middleware

Tests → real endpoint tests verifying correctness & filtering logic

🔎 Filtering Logic

User submits a startDate and endDate.

The API iterates each day in that closed range.

A home is included only if all those days exist in its AvailableSlots.

✅ Example:

Requested range: 2025-07-15 → 2025-07-16

Home slots: ["2025-07-15", "2025-07-16", "2025-07-17"] → Included

Home slots: ["2025-07-15", "2025-07-17"] → Excluded

⚙️ How to Get
1. Clone the repository
git clone https://github.com/elchinabraham/Booking.Service.git


The API will start at:
👉 https://localhost:5001/swagger/index.html

📡 Example Request
GET /api/availablehomes?startDate=2025-07-15&endDate=2025-07-16

✅ Response:
{
  "status": "OK",
  "homes": [
    {
      "homeId": "123",
      "homeName": "Home 1",
      "availableSlots": [
        "2025-07-15",
        "2025-07-16",
        "2025-07-17"
      ]
    }
  ]
}

🧪 Running Tests
Run all tests
dotnet test BookingApi.IntegrationTests

Covered Scenarios

✅ Home returned when all range dates exist

❌ Home excluded when any date is missing

✅ Multiple homes matching the range

❌ No homes available in range

❌ Invalid date inputs → 400 Bad Request

🛠️ Technologies Used

.NET 8.0

Clean Architecture / DDD

AutoMapper

FluentValidation

Serilog

xUnit + FluentAssertions

WebApplicationFactory for integration tests

InMemory Repository (no database)

🎯 Success Criteria

Performance → optimized with HashSet<DateTime> and async filtering

Accuracy → strict closed-range subset check

Testing → verified with integration tests

Architecture → clean, layered, SOLID-compliant

Readability → well-structured, maintainable code

📖 Summary

This project demonstrates how to build a production-ready booking API with modern .NET practices.
It showcases clean coding, testability, performance optimization, and robust error handling — making it an excellent example of how to design a scalable API from scratch.

👉 Would you like me to also add a diagram (ASCII or PlantUML) in the README to visually show how requests flow through layers (API → Application → Domain → Infrastructure)?
