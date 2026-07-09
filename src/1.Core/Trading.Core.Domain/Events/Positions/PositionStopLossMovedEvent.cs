using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionStopLossMovedEvent(
    BaseEntityId PositionId,
    decimal StopLoss)
    : DomainEvent;