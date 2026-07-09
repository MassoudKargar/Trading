namespace Trading.Core.ApplicationService.Common.Models.Spreads;

public sealed record SpreadInfo(string Symbol, decimal Bid, decimal Ask, decimal Spread, DateTime Timestamp);