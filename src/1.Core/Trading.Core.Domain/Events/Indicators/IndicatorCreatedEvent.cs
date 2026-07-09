using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Indicators;

public sealed record IndicatorCreatedEvent(
    BaseEntityId IndicatorId,
    string Name,
    IndicatorType Type)
    : DomainEvent;