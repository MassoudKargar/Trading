using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Orders;
using Trading.Core.RequestResponse.Orders.Commands.SetTakeProfit;

namespace Trading.Core.ApplicationService.Orders.CommandHandlers;

public sealed class SetTakeProfitCommandHandler(
    BaseServices baseServices,
    IOrderRepository repository)
    : CommandHandler<SetTakeProfitCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        SetTakeProfitCommand command,
        CancellationToken cancellationToken)
    {
        var order = await repository.GetAsync(
            command.OrderId,
            cancellationToken);

        if (order is null)
            return Result(ApplicationServiceStatus.NotFound);

        order.SetTakeProfit(command.TakeProfit);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}