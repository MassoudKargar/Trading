using Trading.Core.Domain.Symbols;
using Trading.Core.RequestResponse.Symbols.Commands.CreateSymbol;

namespace Trading.Core.ApplicationService.Symbols.CommandHandlers;

public sealed class CreateSymbolCommandHandler(
    BaseServices baseServices,
    ISymbolRepository repository)
    : CommandHandler<CreateSymbolCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        CreateSymbolCommand command,
        CancellationToken cancellationToken)
    {
        var symbol = Symbol.Create(
            command.Name,
            command.BaseCurrency,
            command.QuoteCurrency,
            command.Digits,
            command.TickSize,
            command.LotSize);

        await repository.InsertAsync(
            symbol,
            cancellationToken);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}