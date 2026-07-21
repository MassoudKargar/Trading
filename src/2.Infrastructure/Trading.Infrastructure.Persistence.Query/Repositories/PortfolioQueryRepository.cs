using Trading.Core.Contracts.Portfolio;
using Trading.Core.Contracts.Portfolio.Queries;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class PortfolioQueryRepository(TradingQueryDbContext dbContext)
    : IPortfolioQueryRepository
{
    public IQueryable<GetAllPortfolioQueryResult> GetAll()
        => dbContext.Portfolios
            .AsNoTracking()
            .Select(x => new GetAllPortfolioQueryResult
            {
                PortfolioId = x.Id,
                AccountId = x.AccountId,
                Balance = x.Balance,
                Equity = x.Equity,
                FloatingProfit = x.FloatingProfit,
                RealizedProfit = x.RealizedProfit,
                TotalProfit = x.TotalProfit,
                Drawdown = x.Drawdown,
                OpenPositions = x.OpenPositions,
                TotalTrades = x.TotalTrades,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });

    public Task<GetPortfolioByIdQueryResult?> GetByIdAsync(
        BaseEntityId portfolioId,
        CancellationToken cancellationToken = default)
        => dbContext.Portfolios
            .AsNoTracking()
            .Where(x => x.Id == portfolioId)
            .Select(x => new GetPortfolioByIdQueryResult
            {
                PortfolioId = x.Id,
                AccountId = x.AccountId,
                Balance = x.Balance,
                Equity = x.Equity,
                FloatingProfit = x.FloatingProfit,
                RealizedProfit = x.RealizedProfit,
                TotalProfit = x.TotalProfit,
                Drawdown = x.Drawdown,
                MaxDrawdown = x.MaxDrawdown,
                Positions = dbContext.Positions
                    .Where(position => position.PortfolioId == x.Id)
                    .Select(position => position.Id)
                    .ToList(),
                Trades = dbContext.Trades
                    .Where(trade => trade.PortfolioId == x.Id)
                    .Select(trade => trade.Id)
                    .ToList(),
                OpenPositions = x.OpenPositions,
                TotalTrades = x.TotalTrades,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

    public Task<GetPortfolioStatisticsQueryResult?> GetStatisticsAsync(
        BaseEntityId portfolioId,
        CancellationToken cancellationToken = default)
        => dbContext.Portfolios
            .AsNoTracking()
            .Where(x => x.Id == portfolioId)
            .Select(x => new GetPortfolioStatisticsQueryResult
            {
                PortfolioId = x.Id,
                Balance = x.Balance,
                Equity = x.Equity,
                FloatingProfit = x.FloatingProfit,
                RealizedProfit = x.RealizedProfit,
                TotalProfit = x.TotalProfit,
                Drawdown = x.Drawdown,
                MaxDrawdown = x.MaxDrawdown,
                OpenPositions = x.OpenPositions,
                TotalTrades = x.TotalTrades
            })
            .FirstOrDefaultAsync(cancellationToken);
}
