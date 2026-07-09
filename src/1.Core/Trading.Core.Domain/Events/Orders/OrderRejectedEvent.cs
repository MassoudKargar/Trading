namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderRejectedEvent(
    BaseEntityId OrderId)
    : DomainEvent;