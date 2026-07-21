namespace Trading.Core.Domain.Symbols;

public sealed class TradingHours : BaseValueObject<TradingHours>
{
    private readonly List<SymbolSession> _sessions = [];

    public IReadOnlyCollection<SymbolSession> Sessions
        => _sessions.AsReadOnly();

    public void AddSession(SymbolSession session)
    {
        _sessions.Add(session);
    }

    public bool IsMarketOpen(DateTime utcNow)
    {
        var session = _sessions.FirstOrDefault(x => x.Day == utcNow.DayOfWeek);

        if (session is null)
            return false;

        return session.IsOpen(TimeOnly.FromDateTime(utcNow));
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        foreach (var session in _sessions.OrderBy(x => x.Day))
        {
            yield return session.Day;
            yield return session.OpenTime;
            yield return session.CloseTime;
            yield return session.IsTradingDay;
        }
    }
}
