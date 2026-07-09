using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record RiskRuleAddedEvent(
    BaseEntityId RiskProfileId,
    string RuleName)
    : DomainEvent;