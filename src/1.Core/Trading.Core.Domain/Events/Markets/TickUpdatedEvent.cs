using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Markets;

public sealed record TickUpdatedEvent(
    BaseEntityId TickId,
    decimal Bid,
    decimal Ask)
    : DomainEvent;