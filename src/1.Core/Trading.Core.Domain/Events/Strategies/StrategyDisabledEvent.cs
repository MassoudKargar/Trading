using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Strategies;

public sealed record StrategyDisabledEvent(
    BaseEntityId StrategyId)
    : DomainEvent;