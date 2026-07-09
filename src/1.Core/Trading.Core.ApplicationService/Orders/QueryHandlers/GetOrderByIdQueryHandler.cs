using Trading.Core.Contracts.Orders;

namespace Trading.Core.ApplicationService.Orders.QueryHandlers;

public sealed class GetOrderByIdQueryHandler(
    BaseServices baseServices,
    IOrderQueryRepository repository)
    : QueryHandler<OrderQueryFilter, GetOrderByIdQueryResult>(baseServices)
{
    public override async Task<QueryResult<GetOrderByIdQueryResult>> Handle(
        OrderQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository.GetByIdAsync(
                query.OrderId.Value,
                cancellationToken));
    }
}