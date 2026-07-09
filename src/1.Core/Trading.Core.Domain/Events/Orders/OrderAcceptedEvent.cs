namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderAcceptedEvent(
    BaseEntityId OrderId)
    : DomainEvent;