namespace Trading.Core.Domain.Events.Accounts;

public sealed record AccountDeactivatedEvent(
    BaseEntityId AccountId)
    : DomainEvent;