namespace Trading.Core.Contracts.Symbols.Queries;

public sealed class SymbolSessionQueryResult
{
    public DayOfWeek Day { get; set; }

    public TimeOnly OpenTime { get; set; }

    public TimeOnly CloseTime { get; set; }

    public bool IsTradingDay { get; set; }
}