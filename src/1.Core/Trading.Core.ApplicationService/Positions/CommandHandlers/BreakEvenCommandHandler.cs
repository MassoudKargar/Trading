using Base.Core.RequestResponse.Common;
using Trading.Core.Contracts.Positions;
using Trading.Core.RequestResponse.Positions.Commands.BreakEven;

namespace Trading.Core.ApplicationService.Positions.CommandHandlers;

public sealed class BreakEvenCommandHandler(
    BaseServices baseServices,
    IPositionRepository repository)
    : CommandHandler<BreakEvenCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        BreakEvenCommand command,
        CancellationToken cancellationToken)
    {
        var position = await repository.GetAsync(
            command.PositionId,
            cancellationToken);

        if (position is null)
            return Result(ApplicationServiceStatus.NotFound);

        position.BreakEven(command.StopLoss);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}