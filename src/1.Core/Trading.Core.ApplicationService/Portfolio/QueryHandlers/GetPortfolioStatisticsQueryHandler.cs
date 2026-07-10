using Trading.Core.Contracts.Portfolio;
using Trading.Core.Contracts.Portfolio.Queries;

namespace Trading.Core.ApplicationService.Portfolio.QueryHandlers;

public sealed class GetPortfolioStatisticsQueryHandler(
    BaseServices baseServices,
    IPortfolioQueryRepository repository)
    : QueryHandler<PortfolioQueryFilter,
        GetPortfolioStatisticsQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetPortfolioStatisticsQueryResult>> Handle(
        PortfolioQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetStatisticsAsync(
                query.PortfolioId.Value!,
                cancellationToken));
    }
}