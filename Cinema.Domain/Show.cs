namespace Cinema.Domain;

// ENTITY (has an Id) and AGGREGATE ROOT (the only gate to its seats).
public class Show
{
    private readonly List<SeatNumber> _booked = new();
    private readonly int _totalSeats;

    public Guid Id { get; } = Guid.NewGuid();
    public string Movie { get; }

    // Read-only view: outside code cannot call _booked.Add().
    public IReadOnlyList<SeatNumber> BookedSeats => _booked;

    public Show(string movie, int totalSeats)
    {
        if (string.IsNullOrWhiteSpace(movie))
            throw new DomainException("Movie name is required");
        if (totalSeats <= 0)
            throw new DomainException("Seats must be more than zero");

        Movie = movie;
        _totalSeats = totalSeats;
    }

    // The business rules live here, in ONE place.
    public void BookSeat(SeatNumber seat)
    {
        if (_booked.Contains(seat))
            throw new DomainException($"Seat {seat} is already booked");

        if (_booked.Count >= _totalSeats)
            throw new DomainException("Show is full");

        _booked.Add(seat);
    }
}
