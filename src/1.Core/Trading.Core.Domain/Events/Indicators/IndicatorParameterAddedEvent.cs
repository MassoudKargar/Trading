using Trading.Core.Domain.Indicators;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Indicators;

public sealed record IndicatorParameterAddedEvent(
    BaseEntityId IndicatorId,
    IndicatorParameter Parameter)
    : DomainEvent;