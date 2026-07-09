namespace Trading.Core.Domain.Events.Strategy;

public sealed record StrategyStoppedEvent(
    BaseEntityId StrategyId)
    : DomainEvent;