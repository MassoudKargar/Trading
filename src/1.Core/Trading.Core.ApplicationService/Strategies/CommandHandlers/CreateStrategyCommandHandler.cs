using Trading.Core.Contracts.Strategies;
using Trading.Core.Domain.Strategies;
using Trading.Core.RequestResponse.Strategies.Commands.CreateStrategy;

namespace Trading.Core.ApplicationService.Strategies.CommandHandlers;

public sealed class CreateStrategyCommandHandler(
    BaseServices baseServices,
    IStrategyRepository repository)
    : CommandHandler<CreateStrategyCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        CreateStrategyCommand command,
        CancellationToken cancellationToken)
    {
        var strategy = new Strategy(
            command.Name,
            command.Type,
            new StrategySettings(
                command.TimeFrame,
                command.RiskPercent,
                command.RiskReward)
            {
                UseStopLoss = command.UseStopLoss,
                UseTakeProfit = command.UseTakeProfit,
                AllowMultiplePositions = command.AllowMultiplePositions,
                MaxOpenPositions = command.MaxOpenPositions
            });

        await repository.InsertAsync(strategy, cancellationToken);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}