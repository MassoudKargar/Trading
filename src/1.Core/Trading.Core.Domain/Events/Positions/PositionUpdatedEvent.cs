namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionUpdatedEvent(
    BaseEntityId PositionId)
    : DomainEvent;