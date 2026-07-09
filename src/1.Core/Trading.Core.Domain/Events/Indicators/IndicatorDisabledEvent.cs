using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Indicators;

public sealed record IndicatorDisabledEvent(
    BaseEntityId IndicatorId)
    : DomainEvent;