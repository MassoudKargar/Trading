using Base.Core.RequestResponse.Common;

using Trading.Core.RequestResponse.Trades.Commands.UpdateCommission;

namespace Trading.Core.ApplicationService.Trades.CommandHandlers;

public sealed class UpdateCommissionCommandHandler(
    BaseServices baseServices,
    ITradeRepository repository)
    : CommandHandler<UpdateCommissionCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateCommissionCommand command,
        CancellationToken cancellationToken)
    {
        var trade = await repository.GetAsync(
            command.TradeId,
            cancellationToken);

        if (trade is null)
            return Result(ApplicationServiceStatus.NotFound);

        trade.UpdateCommission(command.Commission);

        trade.CalculateProfit();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}