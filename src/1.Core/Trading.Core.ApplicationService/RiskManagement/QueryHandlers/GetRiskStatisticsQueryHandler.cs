using Trading.Core.Contracts.RiskManagement;
using Trading.Core.Contracts.RiskManagement.Queries;

namespace Trading.Core.ApplicationService.RiskManagement.QueryHandlers;

public sealed class GetRiskStatisticsQueryHandler(
    BaseServices baseServices,
    IRiskProfileQueryRepository repository)
    : QueryHandler<RiskProfileQueryFilter,
        GetRiskStatisticsQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetRiskStatisticsQueryResult>> Handle(
        RiskProfileQueryFilter query,
        CancellationToken cancellationToken)
    {
        if (!query.RiskProfileId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var statistics = await repository.GetStatisticsAsync(
            query.RiskProfileId.Value,
            cancellationToken);

        return statistics is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(statistics);
    }
}
