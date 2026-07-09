namespace Trading.Core.Domain.Events.Accounts;

public sealed record AccountUpdatedEvent(
    BaseEntityId AccountId)
    : DomainEvent;