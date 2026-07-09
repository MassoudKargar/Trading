using Trading.Core.Domain.Enumerations.Orders;
using Trading.Core.Domain.Enumerations.Trades;
using Trading.Core.Domain.Events.Trades;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Trades;

public sealed class Trade : AggregateRoot<BaseEntityId>
{
    public Trade(
        BaseEntityId positionId,
        string symbol,
        OrderSide side,
        decimal volume,
        decimal entryPrice)
    {
        Id = BaseEntityId.New();
        PositionId = positionId;
        Symbol = symbol;
        Side = side;
        Volume = volume;
        EntryPrice = entryPrice;

        EntryTime = DateTime.UtcNow;
        AddEvent(new TradeOpenedEvent(
            Id,
            PositionId,
            Symbol,
            EntryPrice,
            Volume));
    }

    public BaseEntityId PositionId { get; private set; }

    public string Symbol { get; private set; } = default!;

    public OrderSide Side { get; private set; }

    public decimal Volume { get; private set; }

    public decimal EntryPrice { get; private set; }

    public decimal ExitPrice { get; private set; }

    public decimal GrossProfit { get; private set; }

    public decimal NetProfit { get; private set; }

    public decimal Commission { get; private set; }

    public decimal Swap { get; private set; }

    public TimeSpan Duration { get; private set; }

    public DateTime EntryTime { get; private set; }

    public DateTime? ExitTime { get; private set; }

    public TradeStatus Status { get; private set; } = TradeStatus.Open;

    public void Close(
        decimal exitPrice,
        decimal grossProfit,
        decimal commission,
        decimal swap)
    {
        ExitPrice = exitPrice;

        GrossProfit = grossProfit;

        Commission = commission;

        Swap = swap;

        NetProfit = grossProfit - commission - swap;

        ExitTime = DateTime.UtcNow;

        Duration = ExitTime.Value - EntryTime;

        Status = TradeStatus.Closed;

        AddEvent(new TradeClosedEvent(
            Id,
            ExitPrice,
            NetProfit));

        AddEvent(new TradeCompletedEvent(
            Id,
            Duration,
            NetProfit));

        if (NetProfit > 0)
        {
            AddEvent(new TradeWonEvent(
                Id,
                NetProfit));
        }
        else if (NetProfit < 0)
        {
            AddEvent(new TradeLostEvent(
                Id,
                Math.Abs(NetProfit)));
        }
        else
        {
            AddEvent(new TradeBreakEvenEvent(
                Id));
        }
    }
    public void UpdateCommission(decimal commission)
    {
        Commission = commission;

        AddEvent(new TradeCommissionCalculatedEvent(
            Id,
            commission));
    }
    public void UpdateSwap(decimal swap)
    {
        Swap = swap;

        AddEvent(new TradeSwapCalculatedEvent(
            Id,
            swap));
    }
    public void CalculateProfit()
    {
        NetProfit = GrossProfit - Commission - Swap;

        AddEvent(new TradeProfitCalculatedEvent(
            Id,
            GrossProfit,
            NetProfit));
    }
    public void CalculateDuration()
    {
        Duration = DateTime.UtcNow - EntryTime;

        AddEvent(new TradeDurationCalculatedEvent(
            Id,
            Duration));
    }
    public bool IsProfit()
        => NetProfit > 0;

    public bool IsLoss()
        => NetProfit < 0;

    public bool IsBreakEven()
        => NetProfit == 0;
}