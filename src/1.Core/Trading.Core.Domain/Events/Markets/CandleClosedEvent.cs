using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Markets;

public sealed record CandleClosedEvent(
    BaseEntityId CandleId,
    DateTime CloseTime)
    : DomainEvent;