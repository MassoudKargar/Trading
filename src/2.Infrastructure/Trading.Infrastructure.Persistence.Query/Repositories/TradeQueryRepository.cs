using Trading.Core.Contracts.Trades;
using Trading.Core.Contracts.Trades.Queries;
using Trading.Core.Resources.Enumerations.Trades;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class TradeQueryRepository(TradingQueryDbContext dbContext)
    : ITradeQueryRepository
{
    public IQueryable<GetAllTradeQueryResult> GetAll()
        => dbContext.Trades
            .AsNoTracking()
            .Select(x => new GetAllTradeQueryResult
            {
                TradeId = x.Id,
                PositionId = x.PositionId,
                Symbol = x.Symbol,
                Side = x.Side,
                Volume = x.Volume,
                EntryPrice = x.EntryPrice,
                ExitPrice = x.ExitPrice,
                NetProfit = x.NetProfit,
                Status = x.Status,
                EntryTime = x.EntryTime,
                ExitTime = x.ExitTime
            });

    public IQueryable<GetOpenTradeQueryResult> GetAllOpen()
        => dbContext.Trades
            .AsNoTracking()
            .Where(x => x.Status == TradeStatus.Open)
            .Select(x => new GetOpenTradeQueryResult
            {
                TradeId = x.Id,
                PositionId = x.PositionId,
                Symbol = x.Symbol,
                Side = x.Side,
                Volume = x.Volume,
                EntryPrice = x.EntryPrice,
                Status = x.Status,
                EntryTime = x.EntryTime
            });

    public Task<GetTradeByIdQueryResult?> GetByIdAsync(
        BaseEntityId tradeId,
        CancellationToken cancellationToken = default)
        => dbContext.Trades
            .AsNoTracking()
            .Where(x => x.Id == tradeId)
            .Select(x => new GetTradeByIdQueryResult
            {
                TradeId = x.Id,
                PositionId = x.PositionId,
                Symbol = x.Symbol,
                Side = x.Side,
                Volume = x.Volume,
                EntryPrice = x.EntryPrice,
                ExitPrice = x.ExitPrice,
                GrossProfit = x.GrossProfit,
                Commission = x.Commission,
                Swap = x.Swap,
                NetProfit = x.NetProfit,
                Duration = x.Duration,
                Status = x.Status,
                EntryTime = x.EntryTime,
                ExitTime = x.ExitTime
            })
            .FirstOrDefaultAsync(cancellationToken);
}
