using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeLostEvent(
    BaseEntityId TradeId,
    decimal Loss)
    : DomainEvent;