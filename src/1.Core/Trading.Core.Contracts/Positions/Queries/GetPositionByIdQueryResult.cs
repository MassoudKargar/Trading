using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Enumerations.Positions;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Positions.Queries;

public sealed class GetPositionByIdQueryResult
{
    public BaseEntityId PositionId { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public OrderSide Side { get; set; }

    public decimal Volume { get; set; }

    public decimal EntryPrice { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal? StopLoss { get; set; }

    public decimal? TakeProfit { get; set; }

    public decimal GrossProfit { get; set; }

    public decimal Commission { get; set; }

    public decimal Swap { get; set; }

    public decimal NetProfit { get; set; }

    public PositionStatus Status { get; set; }

    public DateTime OpenedAt { get; set; }

    public DateTime? ClosedAt { get; set; }
}