namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionTrailingStopActivatedEvent(
    BaseEntityId PositionId,
    decimal StopLoss)
    : DomainEvent;