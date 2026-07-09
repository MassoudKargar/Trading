namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionMarginCallEvent(
    BaseEntityId PositionId)
    : DomainEvent;