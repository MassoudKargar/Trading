namespace Trading.Core.Domain.Events.Strategy;

public sealed record StrategyDisabledEvent(
    BaseEntityId StrategyId)
    : DomainEvent;