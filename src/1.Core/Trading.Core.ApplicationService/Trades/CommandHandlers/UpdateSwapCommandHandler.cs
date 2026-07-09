using Base.Core.RequestResponse.Common;

using Trading.Core.RequestResponse.Trades.Commands.UpdateSwap;

namespace Trading.Core.ApplicationService.Trades.CommandHandlers;

public sealed class UpdateSwapCommandHandler(
    BaseServices baseServices,
    ITradeRepository repository)
    : CommandHandler<UpdateSwapCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateSwapCommand command,
        CancellationToken cancellationToken)
    {
        var trade = await repository.GetAsync(
            command.TradeId,
            cancellationToken);

        if (trade is null)
            return Result(ApplicationServiceStatus.NotFound);

        trade.UpdateSwap(command.Swap);

        trade.CalculateProfit();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}