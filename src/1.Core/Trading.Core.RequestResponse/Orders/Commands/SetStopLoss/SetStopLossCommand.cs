using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Orders.Commands.SetStopLoss;

public sealed class SetStopLossCommand : ICommand
{
    public BaseEntityId OrderId { get; init; } = default!;

    public decimal StopLoss { get; init; }
}