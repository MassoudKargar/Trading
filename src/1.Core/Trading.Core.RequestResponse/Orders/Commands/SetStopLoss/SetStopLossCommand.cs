using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Orders.Commands.SetStopLoss;s

public sealed class SetStopLossCommand : ICommand
{
    public BaseEntityId OrderId { get; init; } = default!;

    public decimal StopLoss { get; init; }
}