using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Strategies;
using Trading.Core.RequestResponse.Strategies.Commands.EnableStrategy;

namespace Trading.Core.ApplicationService.Strategies.CommandHandlers;

public sealed class EnableStrategyCommandHandler(
    BaseServices baseServices,
    IStrategyRepository repository)
    : CommandHandler<EnableStrategyCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        EnableStrategyCommand command,
        CancellationToken cancellationToken)
    {
        var strategy = await repository.GetAsync(
            command.StrategyId,
            cancellationToken);

        if (strategy is null)
            return Result(ApplicationServiceStatus.NotFound);

        strategy.Enable();

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}