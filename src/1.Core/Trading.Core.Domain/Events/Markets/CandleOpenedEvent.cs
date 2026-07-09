namespace Trading.Core.Domain.Events.Markets;

public sealed record CandleOpenedEvent(
    BaseEntityId CandleId,
    string Symbol,
    string TimeFrame,
    DateTime OpenTime)
    : DomainEvent;