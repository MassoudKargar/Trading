namespace Trading.Core.Domain.Events.Accounts;

public sealed record AccountActivatedEvent(
    BaseEntityId AccountId)
    : DomainEvent;