using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Orders;

public sealed record OrderAcceptedEvent(
    BaseEntityId OrderId)
    : DomainEvent;