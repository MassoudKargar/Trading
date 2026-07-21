using Trading.Core.Contracts.Strategies;
using Trading.Core.Contracts.Strategies.Queries;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class StrategyQueryRepository(TradingQueryDbContext dbContext)
    : IStrategyQueryRepository
{
    public IQueryable<GetAllStrategyQueryResult> GetAll()
        => dbContext.Strategies
            .AsNoTracking()
            .Select(x => new GetAllStrategyQueryResult
            {
                StrategyId = x.Id,
                Name = x.Name,
                Type = x.Type,
                Status = x.Status,
                IsEnabled = x.IsEnabled,
                TimeFrame = x.TimeFrame,
                RiskPercent = x.RiskPercent,
                RiskReward = x.RiskReward,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });

    public Task<GetStrategyByIdQueryResult?> GetByIdAsync(
        BaseEntityId strategyId,
        CancellationToken cancellationToken = default)
        => dbContext.Strategies
            .AsNoTracking()
            .Where(x => x.Id == strategyId)
            .Select(x => new GetStrategyByIdQueryResult
            {
                StrategyId = x.Id,
                Name = x.Name,
                Type = x.Type,
                Status = x.Status,
                IsEnabled = x.IsEnabled,
                TimeFrame = x.TimeFrame,
                RiskPercent = x.RiskPercent,
                RiskReward = x.RiskReward,
                UseStopLoss = x.UseStopLoss,
                UseTakeProfit = x.UseTakeProfit,
                AllowMultiplePositions = x.AllowMultiplePositions,
                MaxOpenPositions = x.MaxOpenPositions,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

    public Task<GetStrategyStatusQueryResult?> GetStatusAsync(
        BaseEntityId strategyId,
        CancellationToken cancellationToken = default)
        => dbContext.Strategies
            .AsNoTracking()
            .Where(x => x.Id == strategyId)
            .Select(x => new GetStrategyStatusQueryResult
            {
                StrategyId = x.Id,
                Name = x.Name,
                Status = x.Status,
                IsEnabled = x.IsEnabled,
                UpdatedAt = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);
}
