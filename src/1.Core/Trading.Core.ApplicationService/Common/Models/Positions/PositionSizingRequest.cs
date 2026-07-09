namespace Trading.Core.ApplicationService.Common.Models.Positions;

public sealed record PositionSizingRequest(
    decimal AccountBalance,
    decimal RiskPercent,
    decimal EntryPrice,
    decimal StopLossPrice,
    decimal TickValue,
    decimal ContractSize,
    decimal MinVolume,
    decimal MaxVolume,
    decimal VolumeStep);