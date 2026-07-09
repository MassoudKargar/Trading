using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioFloatingProfitChangedEvent(
    BaseEntityId PortfolioId,
    decimal FloatingProfit)
    : DomainEvent;