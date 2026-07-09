using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Accounts;

public sealed record LeverageChangedEvent(
    BaseEntityId AccountId,
    int Leverage)
    : DomainEvent;