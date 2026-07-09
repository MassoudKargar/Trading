using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeOpenedEvent(
    BaseEntityId TradeId,
    BaseEntityId PositionId,
    string Symbol,
    decimal EntryPrice,
    decimal Volume)
    : DomainEvent;