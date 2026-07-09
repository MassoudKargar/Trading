using Trading.Core.Domain.Strategies;

namespace Trading.Core.Domain.Events.Strategy;

public sealed record StrategySettingsChangedEvent(
    BaseEntityId StrategyId,
    StrategySettings Settings)
    : DomainEvent;