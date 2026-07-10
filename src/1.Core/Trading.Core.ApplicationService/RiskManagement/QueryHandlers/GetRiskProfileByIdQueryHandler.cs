using Trading.Core.Contracts.RiskManagement;
using Trading.Core.Contracts.RiskManagement.Queries;

namespace Trading.Core.ApplicationService.RiskManagement.QueryHandlers;

public sealed class GetRiskProfileByIdQueryHandler(
    BaseServices baseServices,
    IRiskProfileQueryRepository repository)
    : QueryHandler<RiskProfileQueryFilter,
        GetRiskProfileByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetRiskProfileByIdQueryResult>> Handle(
        RiskProfileQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetByIdAsync(
                query.RiskProfileId.Value!,
                cancellationToken));
    }
}