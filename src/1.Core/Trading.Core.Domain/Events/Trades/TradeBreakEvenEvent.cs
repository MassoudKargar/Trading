using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Trades;

public sealed record TradeBreakEvenEvent(
    BaseEntityId TradeId)
    : DomainEvent;