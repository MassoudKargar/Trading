using Trading.Core.Contracts.Positions;
using Trading.Core.Domain.Positions;

using Trading.Core.RequestResponse.Positions.Commands.OpenPosition;

namespace Trading.Core.ApplicationService.Positions.CommandHandlers;

public sealed class OpenPositionCommandHandler(
    BaseServices baseServices,
    IPositionRepository repository)
    : CommandHandler<OpenPositionCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        OpenPositionCommand command,
        CancellationToken cancellationToken)
    {
        var position = new Position(
            command.Symbol,
            command.Side,
            command.Volume,
            command.EntryPrice);

        await repository.InsertAsync(position, cancellationToken);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}