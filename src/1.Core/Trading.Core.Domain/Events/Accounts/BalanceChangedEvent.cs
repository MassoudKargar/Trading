using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Accounts;

public sealed record BalanceChangedEvent(
    BaseEntityId AccountId,
    decimal Balance)
    : DomainEvent;