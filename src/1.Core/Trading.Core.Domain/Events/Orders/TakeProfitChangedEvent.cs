using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.Events.Orders;

public sealed record TakeProfitChangedEvent(
    BaseEntityId OrderId,
    decimal TakeProfit)
    : DomainEvent;