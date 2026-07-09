namespace Trading.Core.Domain.Events.Orders;

public sealed record TakeProfitChangedEvent(
    BaseEntityId OrderId,
    decimal TakeProfit)
    : DomainEvent;