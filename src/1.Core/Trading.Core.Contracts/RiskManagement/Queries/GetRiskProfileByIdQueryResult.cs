using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.RiskManagement.Queries;

public sealed class GetRiskProfileByIdQueryResult
{
    public BaseEntityId RiskProfileId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal RiskPerTrade { get; set; }

    public decimal MaxDailyLoss { get; set; }

    public decimal MaxDrawdown { get; set; }

    public decimal MaxOpenVolume { get; set; }

    public int MaxOpenPositions { get; set; }

    public bool IsEnabled { get; set; }

    public IReadOnlyCollection<RiskRuleQueryResult> Rules { get; set; }
        = [];

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}

public sealed class RiskRuleQueryResult
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsEnabled { get; set; }
}