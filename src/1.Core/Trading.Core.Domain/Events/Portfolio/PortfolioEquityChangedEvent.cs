using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioEquityChangedEvent(
    BaseEntityId PortfolioId,
    decimal Equity)
    : DomainEvent;