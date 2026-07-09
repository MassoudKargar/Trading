using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioPositionAddedEvent(
    BaseEntityId PortfolioId,
    BaseEntityId PositionId)
    : DomainEvent;