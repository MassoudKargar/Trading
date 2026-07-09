using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record MaxDrawdownChangedEvent(
    BaseEntityId RiskProfileId,
    decimal MaxDrawdown)
    : DomainEvent;