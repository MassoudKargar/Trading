namespace Trading.Core.RequestResponse.RiskManagement.Commands.CreateRiskProfile;

public sealed class CreateRiskProfileCommand : ICommand
{
    public string Name { get; init; } = string.Empty;

    public decimal RiskPerTrade { get; init; }
}