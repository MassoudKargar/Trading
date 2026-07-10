using Base.Core.RequestResponse.Common;

using Trading.Core.RequestResponse.Symbols.Commands.UpdateLotSize;

namespace Trading.Core.ApplicationService.Symbols.CommandHandlers;

public sealed class UpdateLotSizeCommandHandler(
    BaseServices baseServices,
    ISymbolRepository repository)
    : CommandHandler<UpdateLotSizeCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateLotSizeCommand command,
        CancellationToken cancellationToken)
    {
        var symbol = await repository.GetAsync(
            command.SymbolId,
            cancellationToken);

        if (symbol is null)
            return Result(ApplicationServiceStatus.NotFound);

        symbol.UpdateLotSize(command.LotSize);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}