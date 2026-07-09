namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionPriceUpdatedEvent(
    BaseEntityId PositionId,
    decimal CurrentPrice)
    : DomainEvent;