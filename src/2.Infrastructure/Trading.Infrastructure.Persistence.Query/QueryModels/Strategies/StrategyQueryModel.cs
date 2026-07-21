using Trading.Core.Resources.Enumerations.Strategies;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Strategies;

public sealed class StrategyQueryModel
{
    public BaseEntityId Id { get; set; }

    public string Name { get; set; } = default!;

    public StrategyType Type { get; set; }

    public StrategyStatus Status { get; set; }

    public bool IsEnabled { get; set; }

    public string TimeFrame { get; set; } = default!;

    public decimal RiskPercent { get; set; }

    public decimal RiskReward { get; set; }

    public bool UseStopLoss { get; set; }

    public bool UseTakeProfit { get; set; }

    public bool AllowMultiplePositions { get; set; }

    public int MaxOpenPositions { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}