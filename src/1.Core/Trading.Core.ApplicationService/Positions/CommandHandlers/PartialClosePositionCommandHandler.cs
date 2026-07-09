using Base.Core.RequestResponse.Common;
using Trading.Core.Contracts.Positions;
using Trading.Core.RequestResponse.Positions.Commands.PartialClosePosition;

namespace Trading.Core.ApplicationService.Positions.CommandHandlers;

public sealed class PartialClosePositionCommandHandler(
    BaseServices baseServices,
    IPositionRepository repository)
    : CommandHandler<PartialClosePositionCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        PartialClosePositionCommand command,
        CancellationToken cancellationToken)
    {
        var position = await repository.GetAsync(
            command.PositionId,
            cancellationToken);

        if (position is null)
            return Result(ApplicationServiceStatus.NotFound);

        position.PartialClose(command.Volume);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}