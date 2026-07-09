using Trading.Core.Domain.Enumerations.Positions;

namespace Trading.Core.ApplicationService.Common.Models.Positions;

public sealed record PositionInfo(
    string PositionId,
    string Symbol,
    PositionSide Side,
    PositionStatus Status,
    decimal Volume,
    decimal EntryPrice,
    decimal CurrentPrice,
    decimal StopLoss,
    decimal TakeProfit,
    decimal Profit,
    DateTime OpenTime);