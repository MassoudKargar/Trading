namespace Trading.Core.ApplicationService.Abstractions.Clock;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }

    DateTime Now { get; }

    DateTimeOffset UtcNowOffset { get; }

    DateOnly Today { get; }

    TimeOnly Time { get; }
}