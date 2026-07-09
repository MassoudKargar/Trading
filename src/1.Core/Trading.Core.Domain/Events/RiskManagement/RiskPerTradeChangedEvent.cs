namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record RiskPerTradeChangedEvent(
    BaseEntityId RiskProfileId,
    decimal RiskPerTrade)
    : DomainEvent;