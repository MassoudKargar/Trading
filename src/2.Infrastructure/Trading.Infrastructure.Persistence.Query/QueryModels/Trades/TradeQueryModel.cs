using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Enumerations.Trades;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Trades;

public sealed class TradeQueryModel
{
    public BaseEntityId Id { get; set; }

    public BaseEntityId PositionId { get; set; }

    public BaseEntityId AccountId { get; set; }

    public BaseEntityId PortfolioId { get; set; }

    public BaseEntityId? StrategyId { get; set; }

    public BaseEntityId? OrderId { get; set; }

    public string Broker { get; set; } = default!;

    public string? BrokerTradeId { get; set; }

    public string Symbol { get; set; } = default!;

    public OrderSide Side { get; set; }

    public TradeStatus Status { get; set; }

    public decimal Volume { get; set; }

    public decimal EntryPrice { get; set; }

    public decimal ExitPrice { get; set; }

    public decimal GrossProfit { get; set; }

    public decimal Commission { get; set; }

    public decimal Swap { get; set; }

    public decimal NetProfit { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }

    public bool IsProfit { get; set; }

    public bool IsLoss { get; set; }

    public bool IsBreakEven { get; set; }
}