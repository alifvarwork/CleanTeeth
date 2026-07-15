namespace CleanTeeth.Domain.ValueObjects;

public record TimeInterval
{
    public DateTime Start { get; }
    public DateTime End { get; }

    public TimeInterval(DateTime start, DateTime end)
    {
        if (start >= end)
        {
            throw new ArgumentException("Start time must be before end time.");
        }
        Start = start;
        End = end;
    }
}
