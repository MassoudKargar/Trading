using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.RiskManagement;

public sealed record RiskRuleRemovedEvent(
    BaseEntityId RiskProfileId,
    string RuleName)
    : DomainEvent;