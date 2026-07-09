namespace Trading.Core.Domain.Events.Accounts;

public sealed record AccountCreatedEvent(
    BaseEntityId AccountId)
    : DomainEvent;