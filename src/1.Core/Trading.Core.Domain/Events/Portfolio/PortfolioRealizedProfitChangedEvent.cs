using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioRealizedProfitChangedEvent(
    BaseEntityId PortfolioId,
    decimal RealizedProfit)
    : DomainEvent;