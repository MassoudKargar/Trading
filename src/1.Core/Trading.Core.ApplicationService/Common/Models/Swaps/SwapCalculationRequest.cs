using Trading.Core.Domain.Enumerations.Positions;

namespace Trading.Core.ApplicationService.Common.Models.Swaps;

public sealed record SwapCalculationRequest(
    string Symbol,
    PositionSide Side,
    decimal Volume,
    DateTime OpenTime,
    DateTime CloseTime);