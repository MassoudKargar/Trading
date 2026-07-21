using Trading.Core.Contracts.Indicators;
using Trading.Core.Contracts.Indicators.Queries;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class IndicatorQueryRepository(TradingQueryDbContext dbContext)
    : IIndicatorQueryRepository
{
    public IQueryable<GetAllIndicatorQueryResult> GetAll()
        => dbContext.Indicators
            .AsNoTracking()
            .Select(x => new GetAllIndicatorQueryResult
            {
                IndicatorId = x.Id,
                Name = x.Name,
                Type = x.Type,
                IsEnabled = x.IsEnabled,
                LastValue = x.LastValue,
                CalculatedAt = x.LastCalculatedAt,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });

    public Task<GetIndicatorByIdQueryResult?> GetByIdAsync(
        BaseEntityId indicatorId,
        CancellationToken cancellationToken = default)
        => dbContext.Indicators
            .AsNoTracking()
            .Where(x => x.Id == indicatorId)
            .Select(x => new GetIndicatorByIdQueryResult
            {
                IndicatorId = x.Id,
                Name = x.Name,
                Type = x.Type,
                IsEnabled = x.IsEnabled,
                Parameters = dbContext.IndicatorParameters
                    .Where(parameter => parameter.IndicatorId == x.Id)
                    .Select(parameter => new IndicatorParameterQueryResult
                    {
                        Name = parameter.Name,
                        Value = parameter.Value
                    })
                    .ToList(),
                LastValue = x.LastValue,
                CalculatedAt = x.LastCalculatedAt,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

    public Task<GetIndicatorValueQueryResult?> GetValueAsync(
        BaseEntityId indicatorId,
        CancellationToken cancellationToken = default)
        => dbContext.Indicators
            .AsNoTracking()
            .Where(x => x.Id == indicatorId)
            .Select(x => new GetIndicatorValueQueryResult
            {
                IndicatorId = x.Id,
                Value = x.LastValue,
                CalculatedAt = x.LastCalculatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);
}
