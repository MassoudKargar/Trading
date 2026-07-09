namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeClosedEvent(
    BaseEntityId TradeId,
    decimal ExitPrice,
    decimal NetProfit)
    : DomainEvent;