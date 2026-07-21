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
        if (!query.IndicatorId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var value = await repository.GetValueAsync(
            query.IndicatorId.Value,
            cancellationToken);

        return value is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(value);
    }
}
