using Trading.Core.Domain.Enumerations.Symbols;

namespace Trading.Core.ApplicationService.Common.Models.Symbols;

public sealed record SymbolInfo(
    string Symbol,
    string BaseAsset,
    string QuoteAsset,
    SymbolType Type,
    decimal TickSize,
    decimal StepSize,
    decimal MinQuantity,
    decimal MaxQuantity,
    decimal MinPrice,
    decimal MaxPrice,
    bool IsTradingEnabled);