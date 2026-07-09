using Base.Core.ApplicationServices.Queries.Extensions;

using Trading.Core.Contracts.Positions;
using Trading.Core.Contracts.Positions.Queries;

namespace Trading.Core.ApplicationService.Positions.QueryHandlers;

public sealed class GetOpenPositionsQueryHandler(
    BaseServices baseServices,
    IPositionQueryRepository repository)
    : QueryHandler<PositionQueryFilter, PagedCollectionQueryResult<GetOpenPositionsQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetOpenPositionsQueryResult>>> Handle(
        PositionQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAllOpen()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}