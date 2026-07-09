using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Positions;

public sealed record PositionLiquidatedEvent(
    BaseEntityId PositionId,
    decimal LiquidationPrice)
    : DomainEvent;