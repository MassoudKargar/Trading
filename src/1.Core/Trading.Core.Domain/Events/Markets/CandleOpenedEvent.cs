using Trading.Core.Resources.Enumerations.Markets;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Markets;

public sealed record CandleOpenedEvent(
    BaseEntityId CandleId,
    string Symbol,
    TimeFrame TimeFrame,
    DateTime OpenTime)
    : DomainEvent;