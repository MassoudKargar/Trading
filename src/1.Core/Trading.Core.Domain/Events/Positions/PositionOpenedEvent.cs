using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionOpenedEvent(
    BaseEntityId PositionId,
    string Symbol,
    decimal EntryPrice,
    decimal Volume)
    : DomainEvent;