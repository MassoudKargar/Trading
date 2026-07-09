using Trading.Core.Domain.Events.Markets;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Market;

public sealed class OrderBook : AggregateRoot<BaseEntityId>
{
    private readonly List<MarketDepth> _bids = [];

    private readonly List<MarketDepth> _asks = [];

    public OrderBook(string symbol)
    {
        Id = BaseEntityId.New();
        Symbol = symbol;

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new OrderBookCreatedEvent(
            Id,
            Symbol));
    }

    public string Symbol { get; private set; } = default!;

    public IReadOnlyCollection<MarketDepth> Bids
        => _bids.AsReadOnly();

    public IReadOnlyCollection<MarketDepth> Asks
        => _asks.AsReadOnly();

    public DateTime UpdatedAt { get; private set; }

    public void SetBids(IEnumerable<MarketDepth> bids)
    {
        _bids.Clear();
        _bids.AddRange(bids);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new OrderBookBidsUpdatedEvent(
            Id));
    }

    public void SetAsks(IEnumerable<MarketDepth> asks)
    {
        _asks.Clear();
        _asks.AddRange(asks);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new OrderBookAsksUpdatedEvent(
            Id));
    }

    public MarketDepth? BestBid
        => _bids.OrderByDescending(x => x.Price).FirstOrDefault();

    public MarketDepth? BestAsk
        => _asks.OrderBy(x => x.Price).FirstOrDefault();
}