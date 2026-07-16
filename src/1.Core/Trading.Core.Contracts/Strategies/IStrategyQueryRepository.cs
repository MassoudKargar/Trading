using Trading.Core.Contracts.Strategies.Queries;

namespace Trading.Core.Contracts.Strategies;

public interface IStrategyQueryRepository : IQueryRepository
{
    IQueryable<GetAllStrategyQueryResult> GetAll();

    Task<GetStrategyByIdQueryResult?> GetByIdAsync(
        BaseEntityId strategyId,
        CancellationToken cancellationToken = default);

    Task<GetStrategyStatusQueryResult?> GetStatusAsync(
        BaseEntityId strategyId,
        CancellationToken cancellationToken = default);
}