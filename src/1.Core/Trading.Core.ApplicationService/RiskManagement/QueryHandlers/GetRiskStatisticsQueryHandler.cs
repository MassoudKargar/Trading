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
        return await ResultAsync(
            await repository.GetStatisticsAsync(
                query.RiskProfileId.Value!,
                cancellationToken));
    }
}