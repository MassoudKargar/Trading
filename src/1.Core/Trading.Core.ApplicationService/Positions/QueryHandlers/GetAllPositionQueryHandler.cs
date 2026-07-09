using Base.Core.ApplicationServices.Queries.Extensions;

using Trading.Core.Contracts.Positions;
using Trading.Core.Contracts.Positions.Queries;

namespace Trading.Core.ApplicationService.Positions.QueryHandlers;

public sealed class GetAllPositionQueryHandler(
    BaseServices baseServices,
    IPositionQueryRepository repository)
    : QueryHandler<PositionQueryFilter, PagedCollectionQueryResult<GetAllPositionQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllPositionQueryResult>>> Handle(
        PositionQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}