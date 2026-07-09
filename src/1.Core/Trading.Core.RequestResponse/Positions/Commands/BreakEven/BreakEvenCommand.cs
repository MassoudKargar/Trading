using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Positions.Commands.BreakEven;

public sealed class BreakEvenCommand : ICommand
{
    public BaseEntityId PositionId { get; init; } = default!;

    public decimal StopLoss { get; init; }
}