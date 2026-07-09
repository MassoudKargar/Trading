using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioCreatedEvent(
    BaseEntityId PortfolioId,
    BaseEntityId AccountId)
    : DomainEvent;