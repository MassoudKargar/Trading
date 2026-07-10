namespace Trading.Core.Contracts.Symbols.Queries;

public sealed class GetSymbolByIdQueryResult
{
    public BaseEntityId SymbolId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string BaseCurrency { get; set; } = string.Empty;

    public string QuoteCurrency { get; set; } = string.Empty;

    public int Digits { get; set; }

    public decimal TickSize { get; set; }

    public decimal LotSize { get; set; }

    public decimal Spread { get; set; }

    public bool IsTradable { get; set; }

    public IReadOnlyCollection<SymbolSessionQueryResult> Sessions { get; set; }
        = [];

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}