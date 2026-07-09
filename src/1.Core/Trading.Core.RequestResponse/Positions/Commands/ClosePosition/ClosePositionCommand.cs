using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Positions.Commands.ClosePosition;

public sealed class ClosePositionCommand : ICommand
{
    public BaseEntityId PositionId { get; init; } = default!;

    public decimal ClosePrice { get; init; }
}