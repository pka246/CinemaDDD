# Cinema Ticket app: DDD in C# and .NET

Requires the .NET 8 SDK.

    dotnet new sln -n CinemaDDD
    dotnet sln add Cinema.Domain Cinema.Application Cinema.Infrastructure Cinema.ConsoleDemo
    dotnet run --project Cinema.ConsoleDemo

Expected output:

    Booked: A1
    Booked: A2
    Blocked: Seat A1 is already booked
    Booked: A3
    Blocked: Show is full
    Same seat? True

| Concept | File |
|---|---|
| Entity + Aggregate Root | Cinema.Domain/Show.cs |
| Value Object | Cinema.Domain/SeatNumber.cs |
| Repository interface | Cinema.Domain/IShowRepository.cs |
| Repository implementation | Cinema.Infrastructure/InMemoryShowRepository.cs |
| Use case | Cinema.Application/BookingService.cs |

Dependencies: ConsoleDemo -> Application -> Domain, and Infrastructure -> Domain.

Homework: add `Show.CancelSeat(SeatNumber seat)`. Throw DomainException if the seat was not booked.
