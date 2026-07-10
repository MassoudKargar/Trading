using Base.Core.RequestResponse.Common;

using Trading.Core.RequestResponse.Symbols.Commands.DisableTrading;

namespace Trading.Core.ApplicationService.Symbols.CommandHandlers;

public sealed class DisableTradingCommandHandler(
    BaseServices baseServices,
    ISymbolRepository repository)
    : CommandHandler<DisableTradingCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        DisableTradingCommand command,
        CancellationToken cancellationToken)
    {
        var symbol = await repository.GetAsync(
            command.SymbolId,
            cancellationToken);

        if (symbol is null)
            return Result(ApplicationServiceStatus.NotFound);

        symbol.DisableTrading();

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}