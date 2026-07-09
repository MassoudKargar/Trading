using Trading.Core.Contracts.Trades.Queries;
using Trading.Core.Resources.Enumerations.Trades;

namespace Trading.Core.ApplicationService.Trades.QueryHandlers;

public sealed class TradeQueryFilter()
    : PagedSortableQueryFilter<TradeQueryFilter.SortTradePropertyNames>(new SortTradePropertyNames()),
        IQuery<PagedCollectionQueryResult<GetAllTradeQueryResult>>,
        IQuery<GetTradeByIdQueryResult>,
        IQuery<PagedCollectionQueryResult<GetOpenTradeQueryResult>>
{
    public sealed class SortTradePropertyNames : ISortablePropertyCollection
    {
        public const string TradeId = nameof(TradeId);
        public const string PositionId = nameof(PositionId);
        public const string Symbol = nameof(Symbol);
        public const string EntryTime = nameof(EntryTime);
        public const string NetProfit = nameof(NetProfit);

        public string GetDefault() => EntryTime;
    }

    public BaseEntityId? TradeId { get; set; }

    public BaseEntityId? PositionId { get; set; }

    public string? Symbol { get; set; }

    public OrderSide? Side { get; set; }

    public TradeStatus? Status { get; set; }
}