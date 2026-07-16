using Trading.Core.Domain.Events.Markets;
using Trading.Core.Resources.Enumerations.Markets;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Market;

public sealed class Candle : AggregateRoot<BaseEntityId>
{
    public Candle(
        string symbol,
        TimeFrame timeFrame,
        DateTime openTime)
    {
        Id = BaseEntityId.New();
        Symbol = symbol;
        TimeFrame = timeFrame;
        OpenTime = openTime;
        AddEvent(new CandleOpenedEvent(
            Id,
            Symbol,
            TimeFrame,
            OpenTime));
    }

    public string Symbol { get; private set; } = default!;

    public TimeFrame TimeFrame { get; private set; }

    public DateTime OpenTime { get; private set; }

    public DateTime? CloseTime { get; private set; }

    public decimal Open { get; private set; }

    public decimal High { get; private set; }

    public decimal Low { get; private set; }

    public decimal Close { get; private set; }

    public decimal Volume { get; private set; }

    public bool IsClosed { get; private set; }

    public void Update(
        decimal high,
        decimal low,
        decimal close,
        decimal volume)
    {
        High = high;
        Low = low;
        Close = close;
        Volume = volume;
        AddEvent(new CandleUpdatedEvent(
            Id,
            High,
            Low,
            Close,
            Volume));
    }

    public void CloseCandle(DateTime closeTime)
    {
        IsClosed = true;
        CloseTime = closeTime;
        AddEvent(new CandleClosedEvent(
            Id,
            CloseTime.Value));
    }
}