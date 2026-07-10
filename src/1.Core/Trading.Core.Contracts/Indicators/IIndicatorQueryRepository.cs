using Trading.Core.Contracts.Indicators.Queries;

namespace Trading.Core.Contracts.Indicators;

public interface IIndicatorQueryRepository
    : IQueryRepository
{
    IQueryable<GetAllIndicatorQueryResult> GetAll();

    Task<GetIndicatorByIdQueryResult?> GetByIdAsync(
        BaseEntityId indicatorId,
        CancellationToken cancellationToken = default);

    Task<GetIndicatorValueQueryResult?> GetValueAsync(
        BaseEntityId indicatorId,
        CancellationToken cancellationToken = default);
}