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
        if (!query.OrderId.HasValue)
            return Result(default!, ApplicationServiceStatus.NotFound);

        var order = await repository.GetByIdAsync(
            query.OrderId.Value,
            cancellationToken);

        return order is null
            ? Result(default!, ApplicationServiceStatus.NotFound)
            : await ResultAsync(order);
    }
}
