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
        throw new NotImplementedException();
    }
}