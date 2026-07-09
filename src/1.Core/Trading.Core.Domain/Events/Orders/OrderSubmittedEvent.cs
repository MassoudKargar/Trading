using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderSubmittedEvent(
    BaseEntityId OrderId)
    : DomainEvent;