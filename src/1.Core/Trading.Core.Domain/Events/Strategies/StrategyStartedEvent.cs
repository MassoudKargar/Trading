namespace Trading.Core.Domain.Events.Strategy;

public sealed record StrategyStartedEvent(
    BaseEntityId StrategyId)
    : DomainEvent;