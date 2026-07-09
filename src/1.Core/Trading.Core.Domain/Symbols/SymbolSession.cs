namespace Trading.Core.Domain.Symbols;

public sealed class SymbolSession 
{
    public DayOfWeek Day { get; private set; }

    public TimeOnly OpenTime { get; private set; }

    public TimeOnly CloseTime { get; private set; }

    public bool IsTradingDay { get; private set; }

    private SymbolSession()
    {
    }

    public SymbolSession(
        DayOfWeek day,
        TimeOnly openTime,
        TimeOnly closeTime,
        bool isTradingDay)
    {
        Day = day;
        OpenTime = openTime;
        CloseTime = closeTime;
        IsTradingDay = isTradingDay;
    }

    public bool IsOpen(TimeOnly now)
    {
        if (!IsTradingDay)
            return false;

        return now >= OpenTime &&
               now <= CloseTime;
    }
}