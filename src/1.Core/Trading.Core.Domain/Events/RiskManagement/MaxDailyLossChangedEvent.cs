using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record MaxDailyLossChangedEvent(
    BaseEntityId RiskProfileId,
    decimal MaxDailyLoss)
    : DomainEvent;