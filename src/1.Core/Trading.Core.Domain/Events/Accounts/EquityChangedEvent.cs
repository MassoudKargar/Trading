using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Accounts;

public sealed record EquityChangedEvent(
    BaseEntityId AccountId,
    decimal Equity)
    : DomainEvent;