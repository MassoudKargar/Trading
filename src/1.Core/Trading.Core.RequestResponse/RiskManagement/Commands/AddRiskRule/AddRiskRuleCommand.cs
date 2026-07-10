using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.AddRiskRule;

public sealed class AddRiskRuleCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;

    public string Name { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;
}