using Base.Core.RequestResponse.Common;

using System;
using System.Collections.Generic;
using System.Text;

using Trading.Core.Contracts.Orders;
using Trading.Core.RequestResponse.Orders.Commands.CancelOrder;

namespace Trading.Core.ApplicationService.Orders.CommandHandlers;

public sealed class CancelOrderCommandHandler(
    BaseServices baseServices,
    IOrderRepository repository)
    : CommandHandler<CancelOrderCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        CancelOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = await repository.GetAsync(
            command.OrderId,
            cancellationToken);

        if (order is null)
            return Result(ApplicationServiceStatus.NotFound);

        order.Cancel();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}