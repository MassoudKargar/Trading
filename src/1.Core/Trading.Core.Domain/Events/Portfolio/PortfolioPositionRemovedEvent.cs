using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioPositionRemovedEvent(
    BaseEntityId PortfolioId,
    BaseEntityId PositionId)
    : DomainEvent;