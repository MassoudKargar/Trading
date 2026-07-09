using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionPartiallyClosedEvent(
    BaseEntityId PositionId,
    decimal ClosedVolume,
    decimal RemainingVolume)
    : DomainEvent;