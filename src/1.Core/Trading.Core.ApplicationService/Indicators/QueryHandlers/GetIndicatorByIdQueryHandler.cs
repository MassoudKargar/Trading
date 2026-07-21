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
        if (!query.IndicatorId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var indicator = await repository.GetByIdAsync(
            query.IndicatorId.Value,
            cancellationToken);

        return indicator is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(indicator);
    }
}
