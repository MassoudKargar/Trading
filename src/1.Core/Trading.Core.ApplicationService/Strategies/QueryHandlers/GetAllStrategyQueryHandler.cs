using Base.Core.ApplicationServices.Queries.Extensions;

using Trading.Core.Contracts.Strategies;
using Trading.Core.Contracts.Strategies.Queries;

namespace Trading.Core.ApplicationService.Strategies.QueryHandlers;

public sealed class GetAllStrategyQueryHandler(
    BaseServices baseServices,
    IStrategyQueryRepository repository)
    : QueryHandler<StrategyQueryFilter,
        PagedCollectionQueryResult<GetAllStrategyQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllStrategyQueryResult>>> Handle(
        StrategyQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}