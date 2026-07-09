using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioUpdatedEvent(
    BaseEntityId PortfolioId)
    : DomainEvent;