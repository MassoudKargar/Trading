namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeCommissionCalculatedEvent(
    BaseEntityId TradeId,
    decimal Commission)
    : DomainEvent;