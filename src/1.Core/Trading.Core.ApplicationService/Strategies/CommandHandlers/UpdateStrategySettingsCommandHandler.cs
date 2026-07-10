using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Strategies;
using Trading.Core.Domain.Strategies;
using Trading.Core.RequestResponse.Strategies.Commands.UpdateStrategySettings;

namespace Trading.Core.ApplicationService.Strategies.CommandHandlers;

public sealed class UpdateStrategySettingsCommandHandler(
    BaseServices baseServices,
    IStrategyRepository repository)
    : CommandHandler<UpdateStrategySettingsCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateStrategySettingsCommand command,
        CancellationToken cancellationToken)
    {
        var strategy = await repository.GetAsync(
            command.StrategyId,
            cancellationToken);

        if (strategy is null)
            return Result(ApplicationServiceStatus.NotFound);

        strategy.UpdateSettings(
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

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}