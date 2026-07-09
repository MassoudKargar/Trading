namespace Trading.Core.ApplicationService.Trades.CommandHandlers;

public sealed class OpenTradeCommandHandler(
    BaseServices baseServices,
    ITradeRepository repository)
    : CommandHandler<OpenTradeCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        OpenTradeCommand command,
        CancellationToken cancellationToken)
    {
        var trade = new Trade(
            command.PositionId,
            command.Symbol,
            command.Side,
            command.Volume,
            command.EntryPrice);

        await repository.InsertAsync(trade, cancellationToken);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}