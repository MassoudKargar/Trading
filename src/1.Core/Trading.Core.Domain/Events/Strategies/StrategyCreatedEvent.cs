using Trading.Core.Resources.Enumerations.Strategies;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Strategies;

public sealed record StrategyCreatedEvent(
    BaseEntityId StrategyId,
    string Name,
    StrategyType Type)
    : DomainEvent;