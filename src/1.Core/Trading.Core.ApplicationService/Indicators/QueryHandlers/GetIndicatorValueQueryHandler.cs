using Trading.Core.Contracts.Indicators;
using Trading.Core.Contracts.Indicators.Queries;

namespace Trading.Core.ApplicationService.Indicators.QueryHandlers;

public sealed class GetIndicatorValueQueryHandler(
    BaseServices baseServices,
    IIndicatorQueryRepository repository)
    : QueryHandler<IndicatorQueryFilter,
        GetIndicatorValueQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetIndicatorValueQueryResult>> Handle(
        IndicatorQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetValueAsync(
                query.IndicatorId.Value!,
                cancellationToken));
    }
}