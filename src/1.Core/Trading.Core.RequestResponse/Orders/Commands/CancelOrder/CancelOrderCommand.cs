using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Orders.Commands.CancelOrder;

public sealed class CancelOrderCommand : ICommand
{
    public BaseEntityId OrderId { get; init; } = default!;
}