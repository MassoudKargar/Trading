using Base.Core.ApplicationServices.Queries.Extensions;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.Contracts.RiskManagement.Queries;

namespace Trading.Core.ApplicationService.RiskManagement.QueryHandlers;

public sealed class GetAllRiskProfileQueryHandler(
    BaseServices baseServices,
    IRiskProfileQueryRepository repository)
    : QueryHandler<RiskProfileQueryFilter,
        PagedCollectionQueryResult<GetAllRiskProfileQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllRiskProfileQueryResult>>> Handle(
        RiskProfileQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}