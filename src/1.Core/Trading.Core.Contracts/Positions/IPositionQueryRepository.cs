using Trading.Core.Contracts.Positions.Queries;

namespace Trading.Core.Contracts.Positions;

public interface IPositionQueryRepository
    : IQueryRepository
{
    IQueryable<GetAllPositionQueryResult> GetAll();

    IQueryable<GetOpenPositionsQueryResult> GetAllOpen();

    Task<GetPositionByIdQueryResult?> GetByIdAsync(
        BaseEntityId id,
        CancellationToken cancellationToken = default);
}