namespace Trading.Core.Domain.Events.Strategy;

public sealed record StrategyEnabledEvent(
    BaseEntityId StrategyId)
    : DomainEvent;