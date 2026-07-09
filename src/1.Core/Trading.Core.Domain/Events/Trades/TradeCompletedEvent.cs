using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeCompletedEvent(
    BaseEntityId TradeId,
    TimeSpan Duration,
    decimal NetProfit)
    : DomainEvent;