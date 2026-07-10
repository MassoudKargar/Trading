using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Strategies;
using Trading.Core.RequestResponse.Strategies.Commands.DisableStrategy;

namespace Trading.Core.ApplicationService.Strategies.CommandHandlers;

public sealed class DisableStrategyCommandHandler(
    BaseServices baseServices,
    IStrategyRepository repository)
    : CommandHandler<DisableStrategyCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        DisableStrategyCommand command,
        CancellationToken cancellationToken)
    {
        var strategy = await repository.GetAsync(
            command.StrategyId,
            cancellationToken);

        if (strategy is null)
            return Result(ApplicationServiceStatus.NotFound);

        strategy.Disable();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}