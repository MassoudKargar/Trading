using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Symbols;
using Trading.Core.RequestResponse.Symbols.Commands.EnableTrading;

namespace Trading.Core.ApplicationService.Symbols.CommandHandlers;

public sealed class EnableTradingCommandHandler(
    BaseServices baseServices,
    ISymbolRepository repository)
    : CommandHandler<EnableTradingCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        EnableTradingCommand command,
        CancellationToken cancellationToken)
    {
        var symbol = await repository.GetAsync(
            command.SymbolId,
            cancellationToken);

        if (symbol is null)
            return Result(ApplicationServiceStatus.NotFound);

        symbol.EnableTrading();

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}