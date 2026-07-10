using Base.Core.RequestResponse.Commands;

using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.RemoveRiskRule;

public sealed class RemoveRiskRuleCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;

    public string Name { get; init; } = string.Empty;
}