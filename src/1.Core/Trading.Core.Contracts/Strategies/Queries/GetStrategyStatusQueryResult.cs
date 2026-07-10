using Trading.Core.Resources.Enumerations.Strategies;

namespace Trading.Core.Contracts.Strategies.Queries;

public sealed class GetStrategyStatusQueryResult
{
    public BaseEntityId StrategyId { get; set; }

    public string Name { get; set; } = string.Empty;

    public StrategyStatus Status { get; set; }

    public bool IsEnabled { get; set; }

    public DateTime? UpdatedAt { get; set; }
}