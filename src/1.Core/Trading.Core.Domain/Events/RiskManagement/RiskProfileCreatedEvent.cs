namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record RiskProfileCreatedEvent(
    BaseEntityId RiskProfileId,
    string Name,
    decimal RiskPerTrade)
    : DomainEvent;