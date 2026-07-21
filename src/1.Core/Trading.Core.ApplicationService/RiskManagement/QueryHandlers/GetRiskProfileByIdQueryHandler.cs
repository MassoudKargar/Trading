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
        if (!query.RiskProfileId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var riskProfile = await repository.GetByIdAsync(
            query.RiskProfileId.Value,
            cancellationToken);

        return riskProfile is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(riskProfile);
    }
}
