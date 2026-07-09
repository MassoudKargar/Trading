namespace Trading.Core.ApplicationService.Orders.QueryHandlers;

public sealed class OrderQueryFilter()
    : PagedSortableQueryFilter<OrderQueryFilter.SortOrderPropertyNames>(new SortOrderPropertyNames()),
        IQuery<PagedCollectionQueryResult<GetAllOrderQueryResult>>,
        IQuery<GetOrderByIdQueryResult>,
        IQuery<PagedCollectionQueryResult<GetOpenOrdersQueryResult>>
{
    public sealed class SortOrderPropertyNames : ISortablePropertyCollection
    {
        public const string OrderId = nameof(OrderId);
        public const string Symbol = nameof(Symbol);
        public const string Status = nameof(Status);
        public const string Volume = nameof(Volume);
        public const string Price = nameof(Price);
        public const string CreatedAt = nameof(CreatedAt);

        public string GetDefault() => CreatedAt;
    }

    public BaseEntityId? OrderId { get; set; }

    public string? Symbol { get; set; }

    public OrderStatus? Status { get; set; }

    public OrderType? OrderType { get; set; }

    public OrderSide? Side { get; set; }
}