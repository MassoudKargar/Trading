namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionClosedEvent(
    BaseEntityId PositionId,
    decimal ExitPrice,
    decimal NetProfit)
    : DomainEvent;