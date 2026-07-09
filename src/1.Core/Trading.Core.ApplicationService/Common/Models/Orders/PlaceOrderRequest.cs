using Trading.Core.Domain.Enumerations;
using Trading.Core.Domain.Enumerations.Orders;

namespace Trading.Core.ApplicationService.Common.Models.Orders;

public sealed record PlaceOrderRequest(
    string Symbol,
    OrderSide Side,
    OrderType Type,
    decimal Quantity,
    decimal? Price = null,
    decimal? StopLoss = null,
    decimal? TakeProfit = null);