namespace Trading.Core.Domain.Events.Portfolio;

public sealed record PortfolioBalanceChangedEvent(
    BaseEntityId PortfolioId,
    decimal Balance)
    : DomainEvent;