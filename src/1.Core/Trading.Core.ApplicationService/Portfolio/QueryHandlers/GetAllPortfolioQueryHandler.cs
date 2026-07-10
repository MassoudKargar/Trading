using Base.Core.ApplicationServices.Queries.Extensions;

using Trading.Core.Contracts.Portfolio;
using Trading.Core.Contracts.Portfolio.Queries;

namespace Trading.Core.ApplicationService.Portfolio.QueryHandlers;

public sealed class GetAllPortfolioQueryHandler(
    BaseServices baseServices,
    IPortfolioQueryRepository repository)
    : QueryHandler<PortfolioQueryFilter,
        PagedCollectionQueryResult<GetAllPortfolioQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllPortfolioQueryResult>>> Handle(
        PortfolioQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}