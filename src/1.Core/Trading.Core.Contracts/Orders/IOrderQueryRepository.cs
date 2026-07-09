using Base.Core.Contracts.Data.Queries;

using Trading.Core.Contracts.Orders.QueryResults;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Orders;

public interface IOrderQueryRepository
    : IQueryRepository
{
    IQueryable<GetAllOrderQueryResult> GetAll();

    Task<GetOrderByIdQueryResult?> GetByIdAsync(
        BaseEntityId orderId,
        CancellationToken cancellationToken = default);
}