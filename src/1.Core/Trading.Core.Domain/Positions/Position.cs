using Trading.Core.Domain.Events.Positions;
using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Enumerations.Positions;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Positions;

public sealed class Position : AggregateRoot<BaseEntityId>
{
    public Position(
        string symbol,
        OrderSide side,
        decimal volume,
        decimal entryPrice)
    {

        Id = BaseEntityId.New();
        Symbol = symbol;
        Side = side;
        Volume = volume;
        EntryPrice = entryPrice;

        CurrentPrice = entryPrice;

        Status = PositionStatus.Open;

        OpenedAt = DateTime.UtcNow;

        Profit = new PositionPnL(0, 0, 0);
        AddEvent(new PositionOpenedEvent(
            Id,
            Symbol,
            EntryPrice,
            Volume));
    }

    public string Symbol { get; private set; } = default!;

    public OrderSide Side { get; private set; }

    public decimal Volume { get; private set; }

    public decimal EntryPrice { get; private set; }

    public decimal CurrentPrice { get; private set; }

    public decimal? StopLoss { get; private set; }

    public decimal? TakeProfit { get; private set; }

    public PositionStatus Status { get; private set; }

    public PositionPnL Profit { get; private set; }

    public DateTime OpenedAt { get; }

    public DateTime? ClosedAt { get; private set; }
    public bool IsTrailingStopEnabled { get; private set; }
    public void UpdatePrice(decimal currentPrice)
    {
        CurrentPrice = currentPrice;
        AddEvent(new PositionPriceUpdatedEvent(
            Id,
            CurrentPrice));
    }

    public void MoveStopLoss(decimal stopLoss)
    {
        StopLoss = stopLoss;
        AddEvent(new PositionStopLossMovedEvent(
            Id,
            stopLoss));
    }

    public void MoveTakeProfit(decimal takeProfit)
    {
        TakeProfit = takeProfit;
        AddEvent(new PositionTakeProfitMovedEvent(
            Id,
            takeProfit));
    }

    public void UpdateProfit(
        decimal grossProfit,
        decimal commission,
        decimal swap)
    {
        Profit = new PositionPnL(
            grossProfit,
            commission,
            swap);
        AddEvent(new PositionProfitUpdatedEvent(
            Id,
            Profit.GrossProfit,
            Profit.NetProfit));
    }

    public void Close(decimal closePrice)
    {
        CurrentPrice = closePrice;

        Status = PositionStatus.Closed;

        ClosedAt = DateTime.UtcNow;
        AddEvent(new PositionClosedEvent(
            Id,
            closePrice,
            Profit.NetProfit));
    }
    public void PartialClose(decimal volume)
    {
        Volume -= volume;

        Status = PositionStatus.PartiallyClosed;

        AddEvent(new PositionPartiallyClosedEvent(
            Id,
            volume,
            Volume));
    }
    public void BreakEven(decimal stopLoss)
    {
        StopLoss = stopLoss;

        AddEvent(new PositionBreakEvenEvent(Id));
    }
    public void Liquidate(decimal liquidationPrice)
    {
        CurrentPrice = liquidationPrice;

        Status = PositionStatus.Closed;

        ClosedAt = DateTime.UtcNow;

        AddEvent(new PositionLiquidatedEvent(
            Id,
            liquidationPrice));
    }
    public void MarginCall()
    {
        AddEvent(new PositionMarginCallEvent(Id));
    }
    public void ActivateTrailingStop(decimal stopLoss)
    {
        IsTrailingStopEnabled = true;
        StopLoss = stopLoss;

        AddEvent(new PositionTrailingStopActivatedEvent(
            Id,
            stopLoss));
    }
    public bool IsBuy()
        => Side == OrderSide.Buy;

    public bool IsSell()
        => Side == OrderSide.Sell;

    public bool IsOpen()
        => Status == PositionStatus.Open;

    public bool IsClosed()
        => Status == PositionStatus.Closed;
}