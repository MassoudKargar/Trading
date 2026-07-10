using Trading.Core.Resources.Enumerations.Strategies;

namespace Trading.Core.RequestResponse.Strategies.Commands.CreateStrategy;

public sealed class CreateStrategyCommand : ICommand
{
    public string Name { get; init; } = string.Empty;

    public StrategyType Type { get; init; }

    public string TimeFrame { get; init; } = string.Empty;

    public decimal RiskPercent { get; init; }

    public decimal RiskReward { get; init; }

    public bool UseStopLoss { get; init; } = true;

    public bool UseTakeProfit { get; init; } = true;

    public bool AllowMultiplePositions { get; init; }

    public int MaxOpenPositions { get; init; } = 1;
}