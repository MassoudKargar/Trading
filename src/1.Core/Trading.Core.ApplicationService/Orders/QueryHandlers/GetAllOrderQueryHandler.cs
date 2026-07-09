using Base.Core.ApplicationServices.Queries.Extensions;

using Trading.Core.Contracts.Orders;

namespace Trading.Core.ApplicationService.Orders.QueryHandlers;

public sealed class GetAllOrderQueryHandler(
    BaseServices baseServices,
    IOrderQueryRepository repository)
    : QueryHandler<OrderQueryFilter, PagedCollectionQueryResult<GetAllOrderQueryResult>>(baseServices)
{
    public override async Task<QueryResult<PagedCollectionQueryResult<GetAllOrderQueryResult>>> Handle(
        OrderQueryFilter query,
        CancellationToken cancellationToken)
    {
        return await ResultAsync(
            await repository
                .GetAll()
                .ApplyFilter(query)
                .ToPagedListAsync(query, cancellationToken));
    }
}