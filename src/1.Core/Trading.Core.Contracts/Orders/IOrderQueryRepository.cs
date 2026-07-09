using Trading.Core.Contracts.Orders.QueryResults;

namespace Trading.Core.Contracts.Orders;

public interface IOrderQueryRepository
    : IQueryRepository
{
    IQueryable<GetAllOrderQueryResult> GetAll();

    Task<GetOrderByIdQueryResult?> GetByIdAsync(
        BaseEntityId orderId,
        CancellationToken cancellationToken = default);
}