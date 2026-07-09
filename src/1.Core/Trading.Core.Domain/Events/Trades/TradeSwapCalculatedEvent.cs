using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeSwapCalculatedEvent(
    BaseEntityId TradeId,
    decimal Swap)
    : DomainEvent;