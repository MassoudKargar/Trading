using Trading.Core.Contracts.Portfolio;
using Trading.Core.Contracts.Portfolio.Queries;

namespace Trading.Core.ApplicationService.Portfolio.QueryHandlers;

public sealed class GetPortfolioByIdQueryHandler(
    BaseServices baseServices,
    IPortfolioQueryRepository repository)
    : QueryHandler<PortfolioQueryFilter,
        GetPortfolioByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetPortfolioByIdQueryResult>> Handle(
        PortfolioQueryFilter query,
        CancellationToken cancellationToken)
    {
        if (!query.PortfolioId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var portfolio = await repository.GetByIdAsync(
            query.PortfolioId.Value,
            cancellationToken);

        return portfolio is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(portfolio);
    }
}
