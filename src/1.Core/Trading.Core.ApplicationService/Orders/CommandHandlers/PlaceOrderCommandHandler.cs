using Trading.Core.Domain.Orders;
using Trading.Core.RequestResponse.Orders.Commands.PlaceOrder;

namespace Trading.Core.ApplicationService.Orders.CommandHandlers;

public sealed class PlaceOrderCommandHandler(
    BaseServices baseServices,
    IOrderRepository repository)
    : CommandHandler<PlaceOrderCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        PlaceOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = new Order(
            command.Symbol,
            command.OrderType,
            command.Side,
            command.Volume,
            command.Price);

        if (command.StopLoss.HasValue)
            order.SetStopLoss(command.StopLoss.Value);

        if (command.TakeProfit.HasValue)
            order.SetTakeProfit(command.TakeProfit.Value);

        await repository.InsertAsync(order, cancellationToken);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}