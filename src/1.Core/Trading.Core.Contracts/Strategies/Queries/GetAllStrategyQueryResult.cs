using Trading.Core.Resources.Enumerations.Strategies;

namespace Trading.Core.Contracts.Strategies.Queries;

public sealed class GetAllStrategyQueryResult
{
    public BaseEntityId StrategyId { get; set; }

    public string Name { get; set; } = string.Empty;

    public StrategyType Type { get; set; }

    public StrategyStatus Status { get; set; }

    public bool IsEnabled { get; set; }

    public string TimeFrame { get; set; } = string.Empty;

    public decimal RiskPercent { get; set; }

    public decimal RiskReward { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}