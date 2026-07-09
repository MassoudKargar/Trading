namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionProfitUpdatedEvent(
    BaseEntityId PositionId,
    decimal GrossProfit,
    decimal NetProfit)
    : DomainEvent;