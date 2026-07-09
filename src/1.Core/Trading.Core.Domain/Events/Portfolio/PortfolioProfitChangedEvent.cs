using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioProfitChangedEvent(
    BaseEntityId PortfolioId,
    decimal TotalProfit)
    : DomainEvent;