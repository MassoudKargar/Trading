namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionBreakEvenEvent(
    BaseEntityId PositionId)
    : DomainEvent;