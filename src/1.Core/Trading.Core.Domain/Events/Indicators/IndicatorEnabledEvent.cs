using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Indicators;

public sealed record IndicatorEnabledEvent(
    BaseEntityId IndicatorId)
    : DomainEvent;