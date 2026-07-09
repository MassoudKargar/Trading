namespace Trading.Core.ApplicationService.Common.Models.Risks;

public sealed record RiskCheckResult(
    bool IsAllowed,
    string? Reason);