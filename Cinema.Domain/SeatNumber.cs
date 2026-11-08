namespace Cinema.Domain;

// VALUE OBJECT: no Id. Two seats with the same Row and Number are equal.
public record SeatNumber(char Row, int Number)
{
    public override string ToString() => $"{Row}{Number}";
}
