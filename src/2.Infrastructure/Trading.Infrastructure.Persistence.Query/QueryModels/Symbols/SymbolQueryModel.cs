using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Symbols;

public sealed class SymbolQueryModel
{
    public BaseEntityId Id { get; set; }

    public string Name { get; set; } = default!;

    public string BaseCurrency { get; set; } = default!;

    public string QuoteCurrency { get; set; } = default!;

    public int Digits { get; set; }

    public decimal TickSize { get; set; }

    public decimal LotSize { get; set; }

    public decimal Spread { get; set; }

    public bool IsTradable { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}