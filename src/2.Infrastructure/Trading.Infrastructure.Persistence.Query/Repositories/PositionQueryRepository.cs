using Trading.Core.Contracts.Positions;
using Trading.Core.Contracts.Positions.Queries;
using Trading.Core.Resources.Enumerations.Positions;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class PositionQueryRepository(TradingQueryDbContext dbContext)
    : IPositionQueryRepository
{
    public IQueryable<GetAllPositionQueryResult> GetAll()
        => dbContext.Positions
            .AsNoTracking()
            .Select(x => new GetAllPositionQueryResult
            {
                PositionId = x.Id,
                Symbol = x.Symbol,
                Side = x.Side,
                Volume = x.Volume,
                EntryPrice = x.EntryPrice,
                CurrentPrice = x.CurrentPrice,
                NetProfit = x.NetProfit,
                Status = x.Status,
                OpenedAt = x.OpenedAt
            });

    public IQueryable<GetOpenPositionsQueryResult> GetAllOpen()
        => dbContext.Positions
            .AsNoTracking()
            .Where(x => x.Status == PositionStatus.Open)
            .Select(x => new GetOpenPositionsQueryResult
            {
                PositionId = x.Id,
                Symbol = x.Symbol,
                Side = x.Side,
                Volume = x.Volume,
                EntryPrice = x.EntryPrice,
                CurrentPrice = x.CurrentPrice,
                StopLoss = x.StopLoss,
                TakeProfit = x.TakeProfit,
                NetProfit = x.NetProfit,
                OpenedAt = x.OpenedAt
            });

    public Task<GetPositionByIdQueryResult?> GetByIdAsync(
        BaseEntityId id,
        CancellationToken cancellationToken = default)
        => dbContext.Positions
            .AsNoTracking()
            .Where(x => x.Id == id)
            .Select(x => new GetPositionByIdQueryResult
            {
                PositionId = x.Id,
                Symbol = x.Symbol,
                Side = x.Side,
                Volume = x.Volume,
                EntryPrice = x.EntryPrice,
                CurrentPrice = x.CurrentPrice,
                StopLoss = x.StopLoss,
                TakeProfit = x.TakeProfit,
                GrossProfit = x.GrossProfit,
                Commission = x.Commission,
                Swap = x.Swap,
                NetProfit = x.NetProfit,
                Status = x.Status,
                OpenedAt = x.OpenedAt,
                ClosedAt = x.ClosedAt
            })
            .FirstOrDefaultAsync(cancellationToken);
}
