namespace Trading.Core.ApplicationService.Common.Models.Orders;

public sealed record OrderBookLevelInfo(
    decimal Price,
    decimal Volume);