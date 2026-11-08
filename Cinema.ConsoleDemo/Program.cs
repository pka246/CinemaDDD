using Cinema.Application;
using Cinema.Domain;
using Cinema.Infrastructure;

var repo = new InMemoryShowRepository();
var show = new Show("Space Adventure", totalSeats: 3);
repo.Add(show);
var booking = new BookingService(repo);

foreach (var n in new[] { 1, 2, 1, 3, 4 })
{
    var seat = new SeatNumber('A', n);
    try
    {
        booking.BookSeat(show.Id, seat);
        Console.WriteLine($"Booked: {seat}");
    }
    catch (DomainException e)
    {
        Console.WriteLine($"Blocked: {e.Message}");
    }
}

// Value Object equality
Console.WriteLine($"Same seat? {new SeatNumber('A', 1) == new SeatNumber('A', 1)}");
