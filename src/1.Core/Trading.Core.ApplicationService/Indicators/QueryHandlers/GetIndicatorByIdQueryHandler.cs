using Trading.Core.Contracts.Indicators;
using Trading.Core.Contracts.Indicators.Queries;

namespace Trading.Core.ApplicationService.Indicators.QueryHandlers;

public sealed class GetIndicatorByIdQueryHandler(
    BaseServices baseServices,
    IIndicatorQueryRepository repository)
    : QueryHandler<IndicatorQueryFilter,
        GetIndicatorByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetIndicatorByIdQueryResult>> Handle(
        IndicatorQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetByIdAsync(
                query.IndicatorId.Value!,
                cancellationToken));
    }
}