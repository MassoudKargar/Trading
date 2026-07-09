namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderFilledEvent(
    BaseEntityId OrderId,
    decimal FilledPrice,
    decimal FilledVolume)
    : DomainEvent;