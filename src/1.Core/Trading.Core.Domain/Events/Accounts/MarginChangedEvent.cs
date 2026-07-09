namespace Trading.Core.Domain.Events.Accounts;

public sealed record MarginChangedEvent(
    BaseEntityId AccountId,
    decimal UsedMargin,
    decimal FreeMargin)
    : DomainEvent;