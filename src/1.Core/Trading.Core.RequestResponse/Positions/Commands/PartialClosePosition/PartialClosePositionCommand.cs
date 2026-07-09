using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Positions.Commands.PartialClosePosition;

public sealed class PartialClosePositionCommand : ICommand
{
    public BaseEntityId PositionId { get; init; } = default!;

    public decimal Volume { get; init; }
}