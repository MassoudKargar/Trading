namespace Trading.Core.ApplicationService.Orders.QueryHandlers;

public static class OrderQueryFilterExtensions
{
    public static IQueryable<GetAllOrderQueryResult> ApplyFilter(
        this IQueryable<GetAllOrderQueryResult> query,
        OrderQueryFilter filter)
    {
        if (filter.OrderId is not null)
            query = query.Where(x => x.OrderId == filter.OrderId);

        if (!string.IsNullOrWhiteSpace(filter.Symbol))
            query = query.Where(x => x.Symbol == filter.Symbol);

        if (filter.Status is not null)
            query = query.Where(x => x.Status == filter.Status);

        if (filter.OrderType is not null)
            query = query.Where(x => x.OrderType == filter.OrderType);

        if (filter.Side is not null)
            query = query.Where(x => x.Side == filter.Side);

        return query;
    }
}