using Trading.Core.Domain.Strategies;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Strategies;

public sealed record StrategySettingsChangedEvent(
    BaseEntityId StrategyId,
    StrategySettings Settings)
    : DomainEvent;