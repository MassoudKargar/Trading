using Trading.Core.ApplicationService.Common.Models.Strategies;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IStrategyExecutor
{
    Task<StrategyExecutionResult> ExecuteAsync(
        StrategyExecutionRequest request,
        CancellationToken cancellationToken = default);
}