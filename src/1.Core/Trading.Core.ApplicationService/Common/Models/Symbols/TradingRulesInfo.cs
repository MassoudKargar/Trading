namespace Trading.Core.ApplicationService.Common.Models.Symbols;

public sealed record TradingRulesInfo(
    string Symbol,
    decimal TickSize,
    decimal StepSize,
    decimal MinQuantity,
    decimal MaxQuantity,
    decimal MinNotional);