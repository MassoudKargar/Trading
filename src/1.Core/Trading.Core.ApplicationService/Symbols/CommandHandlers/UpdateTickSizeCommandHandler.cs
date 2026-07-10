using Base.Core.RequestResponse.Common;

using Trading.Core.RequestResponse.Symbols.Commands.UpdateTickSize;

namespace Trading.Core.ApplicationService.Symbols.CommandHandlers;

public sealed class UpdateTickSizeCommandHandler(
    BaseServices baseServices,
    ISymbolRepository repository)
    : CommandHandler<UpdateTickSizeCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateTickSizeCommand command,
        CancellationToken cancellationToken)
    {
        var symbol = await repository.GetAsync(
            command.SymbolId,
            cancellationToken);

        if (symbol is null)
            return Result(ApplicationServiceStatus.NotFound);

        symbol.UpdateTickSize(command.TickSize);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}