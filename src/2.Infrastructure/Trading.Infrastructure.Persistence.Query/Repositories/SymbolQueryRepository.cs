using Trading.Core.Contracts.Symbols;
using Trading.Core.Contracts.Symbols.Queries;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class SymbolQueryRepository(TradingQueryDbContext dbContext)
    : ISymbolQueryRepository
{
    public IQueryable<GetAllSymbolQueryResult> GetAll()
        => dbContext.Symbols
            .AsNoTracking()
            .Select(x => new GetAllSymbolQueryResult
            {
                SymbolId = x.Id,
                Name = x.Name,
                BaseCurrency = x.BaseCurrency,
                QuoteCurrency = x.QuoteCurrency,
                Spread = x.Spread,
                IsTradable = x.IsTradable,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            });

    public Task<GetSymbolByIdQueryResult?> GetByIdAsync(
        BaseEntityId symbolId,
        CancellationToken cancellationToken = default)
        => dbContext.Symbols
            .AsNoTracking()
            .Where(x => x.Id == symbolId)
            .Select(x => new GetSymbolByIdQueryResult
            {
                SymbolId = x.Id,
                Name = x.Name,
                BaseCurrency = x.BaseCurrency,
                QuoteCurrency = x.QuoteCurrency,
                Digits = x.Digits,
                TickSize = x.TickSize,
                LotSize = x.LotSize,
                Spread = x.Spread,
                IsTradable = x.IsTradable,
                Sessions = dbContext.SymbolSessions
                    .Where(session => session.SymbolId == x.Id)
                    .OrderBy(session => session.Day)
                    .Select(session => new SymbolSessionQueryResult
                    {
                        Day = session.Day,
                        OpenTime = session.OpenTime,
                        CloseTime = session.CloseTime,
                        IsTradingDay = session.IsTradingDay
                    })
                    .ToList(),
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            })
            .FirstOrDefaultAsync(cancellationToken);

    public Task<GetTradingHoursQueryResult?> GetTradingHoursAsync(
        BaseEntityId symbolId,
        CancellationToken cancellationToken = default)
        => dbContext.Symbols
            .AsNoTracking()
            .Where(x => x.Id == symbolId)
            .Select(x => new GetTradingHoursQueryResult
            {
                IsTradable = x.IsTradable,
                Sessions = dbContext.SymbolSessions
                    .Where(session => session.SymbolId == x.Id)
                    .OrderBy(session => session.Day)
                    .Select(session => new SymbolSessionQueryResult
                    {
                        Day = session.Day,
                        OpenTime = session.OpenTime,
                        CloseTime = session.CloseTime,
                        IsTradingDay = session.IsTradingDay
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);
}
