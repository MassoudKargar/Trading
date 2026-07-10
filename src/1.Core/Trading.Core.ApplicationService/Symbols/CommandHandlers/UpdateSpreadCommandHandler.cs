using Base.Core.RequestResponse.Common;

using Trading.Core.RequestResponse.Symbols.Commands.UpdateSpread;

namespace Trading.Core.ApplicationService.Symbols.CommandHandlers;

public sealed class UpdateSpreadCommandHandler(
    BaseServices baseServices,
    ISymbolRepository repository)
    : CommandHandler<UpdateSpreadCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateSpreadCommand command,
        CancellationToken cancellationToken)
    {
        var symbol = await repository.GetAsync(
            command.SymbolId,
            cancellationToken);

        if (symbol is null)
            return Result(ApplicationServiceStatus.NotFound);

        symbol.UpdateSpread(command.Spread);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}