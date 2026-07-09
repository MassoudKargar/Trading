using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Strategies;

public sealed record StrategyEnabledEvent(
    BaseEntityId StrategyId)
    : DomainEvent;