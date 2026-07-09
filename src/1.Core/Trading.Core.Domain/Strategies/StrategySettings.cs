namespace Trading.Core.Domain.Strategies;

public sealed class StrategySettings
{
    public StrategySettings(
        string timeFrame,
        decimal riskPercent,
        decimal riskReward)
    {
        TimeFrame = timeFrame;
        RiskPercent = riskPercent;
        RiskReward = riskReward;
    }

    public string TimeFrame { get; }

    public decimal RiskPercent { get; }

    public decimal RiskReward { get; }

    public bool UseStopLoss { get; init; } = true;

    public bool UseTakeProfit { get; init; } = true;

    public bool AllowMultiplePositions { get; init; }

    public int MaxOpenPositions { get; init; } = 1;
}