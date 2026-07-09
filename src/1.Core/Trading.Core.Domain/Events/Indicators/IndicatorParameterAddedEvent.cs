using Trading.Core.Domain.Indicators;

namespace Trading.Core.Domain.Events.Indicators;

public sealed record IndicatorParameterAddedEvent(
    BaseEntityId IndicatorId,
    IndicatorParameter Parameter)
    : DomainEvent;