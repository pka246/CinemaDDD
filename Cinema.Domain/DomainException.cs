namespace Cinema.Domain;

// Thrown when a business rule is broken.
public class DomainException : Exception
{
    public DomainException(string message) : base(message) { }
}
