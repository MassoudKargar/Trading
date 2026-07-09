namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeProfitCalculatedEvent(
    BaseEntityId TradeId,
    decimal GrossProfit,
    decimal NetProfit)
    : DomainEvent;