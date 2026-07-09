namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderCancelledEvent(
    BaseEntityId OrderId)
    : DomainEvent;