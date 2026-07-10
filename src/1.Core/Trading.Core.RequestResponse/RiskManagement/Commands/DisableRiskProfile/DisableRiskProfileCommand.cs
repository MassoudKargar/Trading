using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.DisableRiskProfile;

public sealed class DisableRiskProfileCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;
}