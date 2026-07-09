using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Orders.QueryResults;

public sealed class GetOrderByIdQueryResult
{
    public BaseEntityId OrderId { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public OrderType OrderType { get; set; }

    public OrderSide Side { get; set; }

    public decimal Volume { get; set; }

    public decimal Price { get; set; }

    public decimal FilledPrice { get; set; }

    public decimal FilledVolume { get; set; }

    public decimal Commission { get; set; }

    public decimal Swap { get; set; }

    public decimal? StopLoss { get; set; }

    public decimal? TakeProfit { get; set; }

    public OrderStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? FilledAt { get; set; }

    public DateTime? CancelledAt { get; set; }
}