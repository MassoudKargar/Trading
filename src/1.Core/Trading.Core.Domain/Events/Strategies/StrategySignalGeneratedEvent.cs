namespace Trading.Core.Domain.Events.Strategy;

public sealed record StrategySignalGeneratedEvent(
    BaseEntityId StrategyId,
    SignalType Signal,
    string Symbol,
    decimal Price)
    : DomainEvent;