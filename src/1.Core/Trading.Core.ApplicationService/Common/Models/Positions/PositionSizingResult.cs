namespace Trading.Core.ApplicationService.Common.Models.Positions;

public sealed record PositionSizingResult(
    decimal Volume,
    decimal RiskAmount);