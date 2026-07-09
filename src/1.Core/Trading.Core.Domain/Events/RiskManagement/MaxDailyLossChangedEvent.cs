namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record MaxDailyLossChangedEvent(
    BaseEntityId RiskProfileId,
    decimal MaxDailyLoss)
    : DomainEvent;