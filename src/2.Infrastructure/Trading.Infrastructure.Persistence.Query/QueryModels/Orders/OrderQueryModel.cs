using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Orders;

public sealed class OrderQueryModel
{
    public BaseEntityId Id { get; set; }

    public BaseEntityId AccountId { get; set; }

    public BaseEntityId PortfolioId { get; set; }

    public BaseEntityId? StrategyId { get; set; }

    public string Broker { get; set; } = default!;

    public string? BrokerOrderId { get; set; }

    public long MagicNumber { get; set; }

    public string Symbol { get; set; } = default!;

    public OrderType OrderType { get; set; }

    public OrderSide Side { get; set; }

    public OrderStatus Status { get; set; }

    public decimal Volume { get; set; }

    public decimal Price { get; set; }

    public decimal FilledPrice { get; set; }

    public decimal FilledVolume { get; set; }

    public decimal Commission { get; set; }

    public decimal Swap { get; set; }

    public decimal? StopLoss { get; set; }

    public decimal? TakeProfit { get; set; }

    public decimal? TriggerPrice { get; set; }

    public DateTime? Expiration { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? FilledAt { get; set; }

    public DateTime? CancelledAt { get; set; }
}