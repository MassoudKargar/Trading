using Trading.Core.Contracts.RiskManagement;
using Trading.Core.Contracts.RiskManagement.Queries;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class RiskProfileQueryRepository(TradingQueryDbContext dbContext)
    : IRiskProfileQueryRepository
{
    public IQueryable<GetAllRiskProfileQueryResult> GetAll()
        => dbContext.RiskProfiles
            .AsNoTracking()
            .Select(x => new GetAllRiskProfileQueryResult
            {
                RiskProfileId = x.Id,
                Name = x.Name,
                RiskPerTrade = x.RiskPerTrade,
                MaxDailyLoss = x.MaxDailyLoss,
                MaxDrawdown = x.MaxDrawdown,
                MaxOpenVolume = x.MaxOpenVolume,
                MaxOpenPositions = x.MaxOpenPositions,
                IsEnabled = x.IsEnabled,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });

    public Task<GetRiskProfileByIdQueryResult?> GetByIdAsync(
        BaseEntityId riskProfileId,
        CancellationToken cancellationToken = default)
        => dbContext.RiskProfiles
            .AsNoTracking()
            .Where(x => x.Id == riskProfileId)
            .Select(x => new GetRiskProfileByIdQueryResult
            {
                RiskProfileId = x.Id,
                Name = x.Name,
                RiskPerTrade = x.RiskPerTrade,
                MaxDailyLoss = x.MaxDailyLoss,
                MaxDrawdown = x.MaxDrawdown,
                MaxOpenVolume = x.MaxOpenVolume,
                MaxOpenPositions = x.MaxOpenPositions,
                IsEnabled = x.IsEnabled,
                Rules = dbContext.RiskRules
                    .Where(rule => rule.RiskProfileId == x.Id)
                    .Select(rule => new RiskRuleQueryResult
                    {
                        Name = rule.Name,
                        Description = rule.Description,
                        IsEnabled = rule.IsEnabled
                    })
                    .ToList(),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

    public Task<GetRiskStatisticsQueryResult?> GetStatisticsAsync(
        BaseEntityId riskProfileId,
        CancellationToken cancellationToken = default)
        => dbContext.RiskProfiles
            .AsNoTracking()
            .Where(x => x.Id == riskProfileId)
            .Select(x => new GetRiskStatisticsQueryResult
            {
                RiskProfileId = x.Id,
                RiskPerTrade = x.RiskPerTrade,
                MaxDailyLoss = x.MaxDailyLoss,
                MaxDrawdown = x.MaxDrawdown,
                MaxOpenVolume = x.MaxOpenVolume,
                MaxOpenPositions = x.MaxOpenPositions,
                RulesCount = x.RulesCount,
                IsEnabled = x.IsEnabled
            })
            .FirstOrDefaultAsync(cancellationToken);
}
