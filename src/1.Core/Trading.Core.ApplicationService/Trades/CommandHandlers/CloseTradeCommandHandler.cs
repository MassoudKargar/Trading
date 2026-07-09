using Base.Core.RequestResponse.Common;

using Trading.Core.RequestResponse.Trades.Commands.CloseTrade;

namespace Trading.Core.ApplicationService.Trades.CommandHandlers;

public sealed class CloseTradeCommandHandler(
    BaseServices baseServices,
    ITradeRepository repository)
    : CommandHandler<CloseTradeCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        CloseTradeCommand command,
        CancellationToken cancellationToken)
    {
        var trade = await repository.GetAsync(
            command.TradeId,
            cancellationToken);

        if (trade is null)
            return Result(ApplicationServiceStatus.NotFound);

        trade.Close(
            command.ExitPrice,
            command.GrossProfit,
            command.Commission,
            command.Swap);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}