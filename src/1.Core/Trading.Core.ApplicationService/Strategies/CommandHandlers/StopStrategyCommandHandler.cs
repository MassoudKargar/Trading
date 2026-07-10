using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Strategies;
using Trading.Core.RequestResponse.Strategies.Commands.StopStrategy;

namespace Trading.Core.ApplicationService.Strategies.CommandHandlers;

public sealed class StopStrategyCommandHandler(
    BaseServices baseServices,
    IStrategyRepository repository)
    : CommandHandler<StopStrategyCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        StopStrategyCommand command,
        CancellationToken cancellationToken)
    {
        var strategy = await repository.GetAsync(
            command.StrategyId,
            cancellationToken);

        if (strategy is null)
            return Result(ApplicationServiceStatus.NotFound);

        strategy.Stop();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}