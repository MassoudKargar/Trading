using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderCancelledEvent(
    BaseEntityId OrderId)
    : DomainEvent;