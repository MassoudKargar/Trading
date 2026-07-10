using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.RiskManagement;

public sealed class GetRiskStatisticsQueryResult
{
    public BaseEntityId RiskProfileId { get; set; }

    public decimal RiskPerTrade { get; set; }

    public decimal MaxDailyLoss { get; set; }

    public decimal MaxDrawdown { get; set; }

    public decimal MaxOpenVolume { get; set; }

    public int MaxOpenPositions { get; set; }

    public int RulesCount { get; set; }

    public bool IsEnabled { get; set; }
}