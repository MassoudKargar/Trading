namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionTakeProfitMovedEvent(
    BaseEntityId PositionId,
    decimal TakeProfit)
    : DomainEvent;