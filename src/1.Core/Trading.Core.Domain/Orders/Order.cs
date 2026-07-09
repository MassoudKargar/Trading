using Trading.Core.Domain.Enumerations.Orders;
using Trading.Core.Domain.Events.Orders;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Orders;

public sealed class Order : AggregateRoot<BaseEntityId>
{
    private Order()
    {
    }

    public Order(
        string symbol,
        OrderType orderType,
        OrderSide side,
        decimal volume,
        decimal price)
    {

        Id = BaseEntityId.New();
        Symbol = symbol;
        OrderType = orderType;
        Side = side;
        Volume = volume;
        Price = price;

        Status = OrderStatus.Pending;

        CreatedAt = DateTime.UtcNow;
        AddEvent(new OrderCreatedEvent(
            Id,
            Symbol,
            Volume));
    }

    public string Symbol { get; private set; } = default!;

    public OrderType OrderType { get; private set; }

    public OrderSide Side { get; private set; }

    public decimal Volume { get; private set; }

    public decimal Price { get; private set; }

    public decimal FilledPrice { get; private set; }

    public decimal FilledVolume { get; private set; }

    public decimal Commission { get; private set; }

    public decimal Swap { get; private set; }

    public StopLoss? StopLoss { get; private set; }

    public decimal? TakeProfit { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime? FilledAt { get; private set; }

    public DateTime? CancelledAt { get; private set; }
    public void Submit()
    {
        Status = OrderStatus.Submitted;

        AddEvent(new OrderSubmittedEvent(Id));
    }
    public void Execute(decimal filledPrice)
    {
        FilledPrice = filledPrice;
        FilledVolume = Volume;

        Status = OrderStatus.Filled;

        FilledAt = DateTime.UtcNow;
        AddEvent(new OrderExecutedEvent(
            Id,
            FilledPrice,
            FilledVolume));

        AddEvent(new OrderFilledEvent(
            Id,
            FilledPrice,
            FilledVolume));
    }
    public void PartialFill(
        decimal filledPrice,
        decimal filledVolume)
    {
        FilledPrice = filledPrice;

        FilledVolume += filledVolume;

        Status = OrderStatus.PartiallyFilled;

        AddEvent(new OrderPartiallyFilledEvent(
            Id,
            FilledVolume));
    }
    public void Cancel()
    {
        Status = OrderStatus.Cancelled;

        CancelledAt = DateTime.UtcNow;
        AddEvent(new OrderCancelledEvent(Id));
    }
    public void Accept()
    {
        Status = OrderStatus.Accepted;

        AddEvent(new OrderAcceptedEvent(Id));
    }
    public void Reject()
    {
        Status = OrderStatus.Rejected;
        AddEvent(new OrderRejectedEvent(Id));
    }

    public void SetStopLoss(decimal price)
    {
        StopLoss = new StopLoss(price);
        AddEvent(new StopLossChangedEvent(
            Id,
            price));
    }

    public void SetTakeProfit(decimal price)
    {
        TakeProfit = price;
        AddEvent(new TakeProfitChangedEvent(
            Id,
            price));
    }

    public void UpdateCommission(decimal commission)
    {
        Commission = commission;
    }

    public void UpdateSwap(decimal swap)
    {
        Swap = swap;
    }
}