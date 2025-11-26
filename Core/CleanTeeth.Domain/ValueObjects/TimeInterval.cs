namespace CleanTeeth.Domain.ValueObjects;

public record TimeInterval
{
    public DateTime Start { get; }
    public DateTime End { get; }
    public TimeInterval(DateTime start, DateTime end)
    {
        if (end <= start)
        {
            throw new ArgumentException("End time must be after start time.");
        }

        Start = start;
        End = end;
    }
}
