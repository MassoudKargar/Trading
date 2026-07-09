using Trading.Core.Domain.Enumerations.Strategy;

namespace Trading.Core.Domain.Events.Strategy;

public sealed record StrategyCreatedEvent(
    BaseEntityId StrategyId,
    string Name,
    StrategyType Type)
    : DomainEvent;