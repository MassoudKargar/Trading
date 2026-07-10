using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.EnableRiskProfile;

public sealed class EnableRiskProfileCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;
}