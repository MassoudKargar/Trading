namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record MaxOpenPositionsChangedEvent(
    BaseEntityId RiskProfileId,
    int MaxOpenPositions)
    : DomainEvent;