using Base.Core.RequestResponse.Common;
using Trading.Core.Contracts.Positions;
using Trading.Core.RequestResponse.Positions.Commands.ClosePosition;

namespace Trading.Core.ApplicationService.Positions.CommandHandlers;

public sealed class ClosePositionCommandHandler(
    BaseServices baseServices,
    IPositionRepository repository)
    : CommandHandler<ClosePositionCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        ClosePositionCommand command,
        CancellationToken cancellationToken)
    {
        var position = await repository.GetAsync(
            command.PositionId,
            cancellationToken);

        if (position is null)
            return Result(ApplicationServiceStatus.NotFound);

        position.Close(command.ClosePrice);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}