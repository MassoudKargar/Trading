using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateMaxOpenVolume;

public sealed class UpdateMaxOpenVolumeCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;

    public decimal MaxOpenVolume { get; init; }
}