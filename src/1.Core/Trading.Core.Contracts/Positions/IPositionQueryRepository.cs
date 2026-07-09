using Base.Core.Contracts.Data.Queries;

using Trading.Core.Contracts.Positions.Queries;
using Trading.Core.Resources.Shared.Base;

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