using Trading.Core.Contracts.Orders;
using Trading.Core.Contracts.Orders.QueryResults;

namespace Trading.Infrastructure.Persistence.Query.Repositories;

public sealed class OrderQueryRepository(TradingQueryDbContext dbContext)
    : IOrderQueryRepository
{
    public IQueryable<GetAllOrderQueryResult> GetAll()
        => dbContext.Orders
            .AsNoTracking()
            .Select(x => new GetAllOrderQueryResult
            {
                OrderId = x.Id,
                Symbol = x.Symbol,
                OrderType = x.OrderType,
                Side = x.Side,
                Volume = x.Volume,
                Price = x.Price,
                FilledVolume = x.FilledVolume,
                FilledPrice = x.FilledPrice,
                Status = x.Status,
                CreatedAt = x.CreatedAt
            });

    public Task<GetOrderByIdQueryResult?> GetByIdAsync(
        BaseEntityId orderId,
        CancellationToken cancellationToken = default)
        => dbContext.Orders
            .AsNoTracking()
            .Where(x => x.Id == orderId)
            .Select(x => new GetOrderByIdQueryResult
            {
                OrderId = x.Id,
                Symbol = x.Symbol,
                OrderType = x.OrderType,
                Side = x.Side,
                Volume = x.Volume,
                Price = x.Price,
                FilledPrice = x.FilledPrice,
                FilledVolume = x.FilledVolume,
                Commission = x.Commission,
                Swap = x.Swap,
                StopLoss = x.StopLoss,
                TakeProfit = x.TakeProfit,
                Status = x.Status,
                CreatedAt = x.CreatedAt,
                FilledAt = x.FilledAt,
                CancelledAt = x.CancelledAt
            })
            .FirstOrDefaultAsync(cancellationToken);
}
