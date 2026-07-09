namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderCreatedEvent(
    BaseEntityId OrderId,
    string Symbol,
    decimal Volume)
    : DomainEvent;