using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateDrawdown;

public sealed class UpdateDrawdownCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;

    public decimal MaxDrawdown { get; init; }
}