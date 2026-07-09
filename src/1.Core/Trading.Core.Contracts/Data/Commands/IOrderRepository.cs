using Trading.Core.Domain.Orders;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface IOrderRepository
    : ICommandRepository<Order, BaseEntityId>
{
}