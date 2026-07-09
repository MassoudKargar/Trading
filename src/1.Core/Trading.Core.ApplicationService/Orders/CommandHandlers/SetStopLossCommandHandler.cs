using Base.Core.RequestResponse.Common;
using Trading.Core.RequestResponse.Orders.Commands.SetStopLoss;

namespace Trading.Core.ApplicationService.Orders.CommandHandlers;

public sealed class SetStopLossCommandHandler(
    BaseServices baseServices,
    IOrderRepository repository)
    : CommandHandler<SetStopLossCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        SetStopLossCommand command,
        CancellationToken cancellationToken)
    {
        var order = await repository.GetAsync(
            command.OrderId,
            cancellationToken);

        if (order is null)
            return Result(ApplicationServiceStatus.NotFound);

        order.SetStopLoss(command.StopLoss);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}