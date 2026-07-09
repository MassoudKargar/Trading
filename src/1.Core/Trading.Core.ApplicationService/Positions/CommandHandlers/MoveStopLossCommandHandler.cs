using Base.Core.RequestResponse.Common;
using Trading.Core.Contracts.Positions;
using Trading.Core.RequestResponse.Positions.Commands.MoveStopLoss;

namespace Trading.Core.ApplicationService.Positions.CommandHandlers;

public sealed class MoveStopLossCommandHandler(
    BaseServices baseServices,
    IPositionRepository repository)
    : CommandHandler<MoveStopLossCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        MoveStopLossCommand command,
        CancellationToken cancellationToken)
    {
        var position = await repository.GetAsync(
            command.PositionId,
            cancellationToken);

        if (position is null)
            return Result(ApplicationServiceStatus.NotFound);

        position.MoveStopLoss(command.StopLoss);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}