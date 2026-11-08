using Cinema.Domain;

namespace Cinema.Application;

// USE CASE: coordinates the steps. It holds NO business rules.
public class BookingService
{
    private readonly IShowRepository _shows;

    public BookingService(IShowRepository shows) => _shows = shows;

    public void BookSeat(Guid showId, SeatNumber seat)
    {
        var show = _shows.Get(showId)
                   ?? throw new DomainException("Show not found");

        show.BookSeat(seat);   // the rules are checked inside Show
    }
}
