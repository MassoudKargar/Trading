namespace Trading.Core.Domain.Enumerations.Risk;

public enum RiskRuleType
{
    DailyLoss = 1,
    Drawdown = 2,
    MaxPosition = 3,
    MaxExposure = 4,
    MaxVolume = 5
}