using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Strategies.Commands.UpdateStrategySettings;

public sealed class UpdateStrategySettingsCommand : ICommand
{
    public BaseEntityId StrategyId { get; init; } = default!;

    public string TimeFrame { get; init; } = string.Empty;

    public decimal RiskPercent { get; init; }

    public decimal RiskReward { get; init; }

    public bool UseStopLoss { get; init; }

    public bool UseTakeProfit { get; init; }

    public bool AllowMultiplePositions { get; init; }

    public int MaxOpenPositions { get; init; }
}