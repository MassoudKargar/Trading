namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeBreakEvenEvent(
    BaseEntityId TradeId)
    : DomainEvent;