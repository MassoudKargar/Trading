using Base.Core.ApplicationServices.Queries.Extensions;

using Trading.Core.Contracts.Indicators;
using Trading.Core.Contracts.Indicators.Queries;

namespace Trading.Core.ApplicationService.Indicators.QueryHandlers;

public sealed class GetAllIndicatorQueryHandler(
    BaseServices baseServices,
    IIndicatorQueryRepository repository)
    : QueryHandler<IndicatorQueryFilter,
        PagedCollectionQueryResult<GetAllIndicatorQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllIndicatorQueryResult>>> Handle(
        IndicatorQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}