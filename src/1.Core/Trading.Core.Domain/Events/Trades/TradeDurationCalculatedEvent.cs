using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeDurationCalculatedEvent(
    BaseEntityId TradeId,
    TimeSpan Duration)
    : DomainEvent;