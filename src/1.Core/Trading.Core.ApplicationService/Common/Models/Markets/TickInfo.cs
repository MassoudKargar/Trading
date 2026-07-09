namespace Trading.Core.ApplicationService.Common.Models.Markets;

public sealed record TickInfo(
    string Symbol,
    decimal Bid,
    decimal Ask,
    DateTime Timestamp);