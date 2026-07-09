using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Markets;

public sealed record OrderBookAsksUpdatedEvent(
    BaseEntityId OrderBookId)
    : DomainEvent;