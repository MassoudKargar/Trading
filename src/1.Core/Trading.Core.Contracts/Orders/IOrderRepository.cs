using Trading.Core.Domain.Orders;

namespace Trading.Core.Contracts.Orders;

public interface IOrderRepository
    : ICommandRepository<Order, BaseEntityId>
{
}