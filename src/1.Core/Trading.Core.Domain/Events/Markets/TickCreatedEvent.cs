using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Markets;

public sealed record TickCreatedEvent(
    BaseEntityId TickId,
    string Symbol,
    decimal Bid,
    decimal Ask)
    : DomainEvent;