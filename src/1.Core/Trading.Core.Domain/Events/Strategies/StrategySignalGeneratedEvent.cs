using Trading.Core.Domain.Enumerations.Strategies;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Strategies;

public sealed record StrategySignalGeneratedEvent(
    BaseEntityId StrategyId,
    SignalType Signal,
    string Symbol,
    decimal Price)
    : DomainEvent;