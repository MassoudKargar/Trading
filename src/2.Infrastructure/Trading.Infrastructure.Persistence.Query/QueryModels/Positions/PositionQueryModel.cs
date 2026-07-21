using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Enumerations.Positions;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Positions;

public sealed class PositionQueryModel
{
    public BaseEntityId Id { get; set; }

    public BaseEntityId PortfolioId { get; set; }

    public BaseEntityId AccountId { get; set; }

    public BaseEntityId? StrategyId { get; set; }

    public BaseEntityId? OrderId { get; set; }

    public string Broker { get; set; } = default!;

    public string? BrokerPositionId { get; set; }

    public string Symbol { get; set; } = default!;

    public OrderSide Side { get; set; }

    public PositionStatus Status { get; set; }

    public decimal Volume { get; set; }

    public decimal EntryPrice { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal? StopLoss { get; set; }

    public decimal? TakeProfit { get; set; }

    public decimal GrossProfit { get; set; }

    public decimal Commission { get; set; }

    public decimal Swap { get; set; }

    public decimal NetProfit { get; set; }

    public bool IsTrailingStopEnabled { get; set; }

    public DateTime OpenedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
}