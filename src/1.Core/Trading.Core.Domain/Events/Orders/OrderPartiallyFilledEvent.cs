using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderPartiallyFilledEvent(
    BaseEntityId OrderId,
    decimal FilledVolume)
    : DomainEvent;