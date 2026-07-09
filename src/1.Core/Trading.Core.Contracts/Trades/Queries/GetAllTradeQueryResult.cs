namespace Trading.Core.Contracts.Trades.Queries;

public sealed class GetAllTradeQueryResult
{
    public BaseEntityId TradeId { get; set; }

    public BaseEntityId PositionId { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public OrderSide Side { get; set; }

    public decimal Volume { get; set; }

    public decimal EntryPrice { get; set; }

    public decimal ExitPrice { get; set; }

    public decimal NetProfit { get; set; }

    public TradeStatus Status { get; set; }

    public DateTime EntryTime { get; set; }

    public DateTime? ExitTime { get; set; }
}