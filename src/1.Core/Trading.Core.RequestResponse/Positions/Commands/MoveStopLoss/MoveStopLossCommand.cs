using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Positions.Commands.MoveStopLoss;

public sealed class MoveStopLossCommand : ICommand
{
    public BaseEntityId PositionId { get; init; } = default!;

    public decimal StopLoss { get; init; }
}