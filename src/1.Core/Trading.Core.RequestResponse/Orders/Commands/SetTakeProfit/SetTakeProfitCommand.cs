using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Orders.Commands.SetTakeProfit;

public sealed class SetTakeProfitCommand : ICommand
{
    public BaseEntityId OrderId { get; init; } = default!;

    public decimal TakeProfit { get; init; }
}