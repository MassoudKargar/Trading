using Trading.Core.Domain.Events.Orders;
using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Shared.Base;
using Trading.Core.Resources.Shared.Guards;

namespace Trading.Core.Domain.Orders;

public sealed class Order : AggregateRoot<BaseEntityId>
{
    private Order()
    {
    }

    public Order(
        BaseEntityId accountId,
        BaseEntityId portfolioId,
        BaseEntityId? strategyId,
        string broker,
        string symbol,
        OrderType orderType,
        OrderSide side,
        decimal volume,
        decimal price)
    {
        Guard.AgainstNullOrWhiteSpace(symbol, nameof(symbol));
        Guard.AgainstNullOrWhiteSpace(broker, nameof(broker));
        Guard.AgainstNegative(volume, nameof(volume));
        Guard.AgainstNegative(price, nameof(price));

        Id = BaseEntityId.New();

        AccountId = accountId;
        PortfolioId = portfolioId;
        StrategyId = strategyId;

        Broker = broker;
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

    public BaseEntityId AccountId { get; private set; }

    public BaseEntityId PortfolioId { get; private set; }

    public BaseEntityId? StrategyId { get; private set; }

    public string Broker { get; private set; } = default!;

    public string? BrokerOrderId { get; private set; }

    public long MagicNumber { get; private set; }

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

    public PendingOrder? PendingOrder { get; private set; }

    public OrderStatus Status { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime? UpdatedAt { get; private set; }

    public DateTime? SubmittedAt { get; private set; }

    public DateTime? AcceptedAt { get; private set; }

    public DateTime? FilledAt { get; private set; }

    public DateTime? CancelledAt { get; private set; }

    public DateTime? RejectedAt { get; private set; }

    public void Submit()
    {
        Status = OrderStatus.Submitted;
        SubmittedAt = DateTime.UtcNow;
        UpdatedAt = SubmittedAt;

        AddEvent(new OrderSubmittedEvent(Id));
    }

    public void Accept()
    {
        Status = OrderStatus.Accepted;
        AcceptedAt = DateTime.UtcNow;
        UpdatedAt = AcceptedAt;

        AddEvent(new OrderAcceptedEvent(Id));
    }

    public void Reject()
    {
        Status = OrderStatus.Rejected;
        RejectedAt = DateTime.UtcNow;
        UpdatedAt = RejectedAt;

        AddEvent(new OrderRejectedEvent(Id));
    }

    public void Execute(decimal filledPrice)
    {
        FilledPrice = filledPrice;
        FilledVolume = Volume;

        Status = OrderStatus.Filled;

        FilledAt = DateTime.UtcNow;
        UpdatedAt = FilledAt;

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

        UpdatedAt = DateTime.UtcNow;

        AddEvent(new OrderPartiallyFilledEvent(
            Id,
            FilledVolume));
    }

    public void Cancel()
    {
        Status = OrderStatus.Cancelled;

        CancelledAt = DateTime.UtcNow;
        UpdatedAt = CancelledAt;

        AddEvent(new OrderCancelledEvent(Id));
    }

    public void SetStopLoss(decimal price)
    {
        StopLoss = new StopLoss(price);

        UpdatedAt = DateTime.UtcNow;

        AddEvent(new StopLossChangedEvent(
            Id,
            price));
    }

    public void SetTakeProfit(decimal price)
    {
        TakeProfit = price;

        UpdatedAt = DateTime.UtcNow;

        AddEvent(new TakeProfitChangedEvent(
            Id,
            price));
    }

    public void SetPendingOrder(
        decimal triggerPrice,
        DateTime expiration)
    {
        PendingOrder = new PendingOrder(
            triggerPrice,
            expiration);

        UpdatedAt = DateTime.UtcNow;
    }

    public void SetBrokerOrderId(string brokerOrderId)
    {
        BrokerOrderId = brokerOrderId;

        UpdatedAt = DateTime.UtcNow;
    }

    public void SetMagicNumber(long magicNumber)
    {
        MagicNumber = magicNumber;

        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateCommission(decimal commission)
    {
        Commission = commission;

        UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateSwap(decimal swap)
    {
        Swap = swap;

        UpdatedAt = DateTime.UtcNow;
    }
}