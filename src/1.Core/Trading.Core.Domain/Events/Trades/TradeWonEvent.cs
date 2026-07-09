using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeWonEvent(
    BaseEntityId TradeId,
    decimal Profit)
    : DomainEvent;