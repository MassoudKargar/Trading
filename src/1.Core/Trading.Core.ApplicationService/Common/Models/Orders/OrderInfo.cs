using Trading.Core.Domain.Enumerations.Orders;

namespace Trading.Core.ApplicationService.Common.Models.Orders;

public sealed record OrderInfo(
    string OrderId,
    string Symbol,
    OrderSide Side,
    OrderType Type,
    OrderStatus Status,
    decimal Price,
    decimal Volume,
    decimal FilledVolume,
    decimal AveragePrice,
    DateTime CreatedAt);