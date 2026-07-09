using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Positions;
using Trading.Core.RequestResponse.Positions.Commands.MoveTakeProfit;

namespace Trading.Core.ApplicationService.Positions.CommandHandlers;

public sealed class MoveTakeProfitCommandHandler(
    BaseServices baseServices,
    IPositionRepository repository)
    : CommandHandler<MoveTakeProfitCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        MoveTakeProfitCommand command,
        CancellationToken cancellationToken)
    {
        var position = await repository.GetAsync(
            command.PositionId,
            cancellationToken);

        if (position is null)
            return Result(ApplicationServiceStatus.NotFound);

        position.MoveTakeProfit(command.TakeProfit);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}