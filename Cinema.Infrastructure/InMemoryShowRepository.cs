using Cinema.Domain;

namespace Cinema.Infrastructure;

// Implements the Domain interface. Later you can swap it for EF Core / SQL
// without changing Domain or Application code.
public class InMemoryShowRepository : IShowRepository
{
    private readonly Dictionary<Guid, Show> _store = new();

    public Show? Get(Guid id) => _store.GetValueOrDefault(id);

    public void Add(Show show) => _store[show.Id] = show;
}
