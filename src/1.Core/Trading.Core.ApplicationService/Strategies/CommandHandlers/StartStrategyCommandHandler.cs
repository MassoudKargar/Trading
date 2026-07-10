using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Strategies;
using Trading.Core.RequestResponse.Strategies.Commands.StartStrategy;

namespace Trading.Core.ApplicationService.Strategies.CommandHandlers;

public sealed class StartStrategyCommandHandler(
    BaseServices baseServices,
    IStrategyRepository repository)
    : CommandHandler<StartStrategyCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        StartStrategyCommand command,
        CancellationToken cancellationToken)
    {
        var strategy = await repository.GetAsync(
            command.StrategyId,
            cancellationToken);

        if (strategy is null)
            return Result(ApplicationServiceStatus.NotFound);

        strategy.Start();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}