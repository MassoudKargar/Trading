using Base.Core.RequestResponse.Common;
using Trading.Core.Contracts.Positions;
using Trading.Core.RequestResponse.Positions.Commands.ActivateTrailingStop;

namespace Trading.Core.ApplicationService.Positions.CommandHandlers;

public sealed class ActivateTrailingStopCommandHandler(
    BaseServices baseServices,
    IPositionRepository repository)
    : CommandHandler<ActivateTrailingStopCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        ActivateTrailingStopCommand command,
        CancellationToken cancellationToken)
    {
        var position = await repository.GetAsync(
            command.PositionId,
            cancellationToken);

        if (position is null)
            return Result(ApplicationServiceStatus.NotFound);

        position.ActivateTrailingStop(command.StopLoss);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}