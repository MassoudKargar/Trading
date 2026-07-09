using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderExecutedEvent(
    BaseEntityId OrderId,
    decimal FilledPrice,
    decimal FilledVolume)
    : IDomainEvent;