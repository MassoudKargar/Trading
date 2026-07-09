namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record RiskProfileEnabledEvent(
    BaseEntityId RiskProfileId)
    : DomainEvent;