using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Positions.Commands.ActivateTrailingStop;

public sealed class ActivateTrailingStopCommand : ICommand
{
    public BaseEntityId PositionId { get; init; } = default!;

    public decimal StopLoss { get; init; }
}