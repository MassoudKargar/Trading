using Trading.Core.Contracts.Positions.Queries;
using Trading.Core.Resources.Enumerations.Positions;

namespace Trading.Core.ApplicationService.Positions.QueryHandlers;

public sealed class PositionQueryFilter()
    : PagedSortableQueryFilter<PositionQueryFilter.SortPositionPropertyNames>(new SortPositionPropertyNames()),
        IQuery<PagedCollectionQueryResult<GetAllPositionQueryResult>>,
        IQuery<GetPositionByIdQueryResult>,
        IQuery<PagedCollectionQueryResult<GetOpenPositionsQueryResult>>
{
    public sealed class SortPositionPropertyNames : ISortablePropertyCollection
    {
        public const string PositionId = nameof(PositionId);
        public const string Symbol = nameof(Symbol);
        public const string Status = nameof(Status);
        public const string Volume = nameof(Volume);
        public const string EntryPrice = nameof(EntryPrice);
        public const string OpenedAt = nameof(OpenedAt);

        public string GetDefault() => OpenedAt;
    }

    public BaseEntityId? PositionId { get; set; }

    public string? Symbol { get; set; }

    public PositionStatus? Status { get; set; }

    public OrderSide? Side { get; set; }
}