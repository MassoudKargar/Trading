using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record RiskProfileDisabledEvent(
    BaseEntityId RiskProfileId)
    : DomainEvent;