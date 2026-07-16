using Trading.Core.Domain.Events.Markets;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Ticks;

public sealed class Tick : AggregateRoot<BaseEntityId>
{
    public Tick(
        string symbol,
        decimal bid,
        decimal ask)
    {
        Id = BaseEntityId.New();
        Symbol = symbol;
        Bid = bid;
        Ask = ask;

        Time = DateTime.UtcNow;
        AddEvent(new TickCreatedEvent(
            Id,
            Symbol,
            Bid,
            Ask));
    }

    public string Symbol { get; private set; } = default!;

    public decimal Bid { get; private set; }

    public decimal Ask { get; private set; }

    public decimal Last => (Bid + Ask) / 2m;

    public DateTime Time { get; private set; }
    public string Broker { get; private set; } = default!;

    public decimal? LastPrice { get; private set; }

    public decimal? Volume { get; private set; }

    public DateTime ServerTime { get; private set; }

    public DateTime ReceivedAt { get; private set; }

    public void Update(decimal bid, decimal ask)
    {
        Bid = bid;
        Ask = ask;

        Time = DateTime.UtcNow;
        AddEvent(new TickUpdatedEvent(
            Id,
            Bid,
            Ask));
    }
}