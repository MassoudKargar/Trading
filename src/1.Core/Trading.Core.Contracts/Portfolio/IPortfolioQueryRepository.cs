using Trading.Core.Contracts.Portfolio.Queries;

namespace Trading.Core.Contracts.Portfolio;

public interface IPortfolioQueryRepository : IQueryRepository
{
    IQueryable<GetAllPortfolioQueryResult> GetAll();

    Task<GetPortfolioByIdQueryResult?> GetByIdAsync(
        BaseEntityId portfolioId,
        CancellationToken cancellationToken = default);

    Task<GetPortfolioStatisticsQueryResult?> GetStatisticsAsync(
        BaseEntityId portfolioId,
        CancellationToken cancellationToken = default);
}