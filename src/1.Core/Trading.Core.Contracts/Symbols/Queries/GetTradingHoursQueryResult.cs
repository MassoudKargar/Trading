namespace Trading.Core.Contracts.Symbols.Queries;

public sealed class GetTradingHoursQueryResult
{
    public IReadOnlyCollection<SymbolSessionQueryResult> Sessions { get; set; }
        = [];

    public bool IsTradable { get; set; }
}
