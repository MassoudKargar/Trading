using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Positions.Commands.MoveTakeProfit;

public sealed class MoveTakeProfitCommand : ICommand
{
    public BaseEntityId PositionId { get; init; } = default!;

    public decimal TakeProfit { get; init; }
}