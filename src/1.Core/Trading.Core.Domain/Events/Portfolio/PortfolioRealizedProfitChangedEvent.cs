namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioRealizedProfitChangedEvent(
    BaseEntityId PortfolioId,
    decimal RealizedProfit)
    : DomainEvent;