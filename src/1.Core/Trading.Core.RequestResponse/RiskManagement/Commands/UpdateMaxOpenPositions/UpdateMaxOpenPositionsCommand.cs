using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateMaxOpenPositions;

public sealed class UpdateMaxOpenPositionsCommand : ICommand
{
    public BaseEntityId RiskProfileId { get; init; } = default!;

    public int MaxOpenPositions { get; init; }
}