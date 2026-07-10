namespace Trading.Core.Contracts.Symbols.Queries;

public sealed class GetAllSymbolQueryResult
{
    public BaseEntityId SymbolId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string BaseCurrency { get; set; } = string.Empty;

    public string QuoteCurrency { get; set; } = string.Empty;

    public decimal Spread { get; set; }

    public bool IsTradable { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}