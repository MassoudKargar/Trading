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
        if (!query.PortfolioId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var statistics = await repository.GetStatisticsAsync(
            query.PortfolioId.Value,
            cancellationToken);

        return statistics is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(statistics);
    }
}
