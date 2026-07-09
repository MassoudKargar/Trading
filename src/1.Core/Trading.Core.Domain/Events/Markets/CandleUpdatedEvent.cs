namespace Trading.Core.Domain.Events.Markets;

public sealed record CandleUpdatedEvent(
    BaseEntityId CandleId,
    decimal High,
    decimal Low,
    decimal Close,
    decimal Volume)
    : DomainEvent;