namespace Cinema.Domain;

// REPOSITORY contract. Domain knows only this interface, never the database.
public interface IShowRepository
{
    Show? Get(Guid id);
    void Add(Show show);
}
