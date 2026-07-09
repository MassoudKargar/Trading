using Trading.Core.ApplicationService.Common.Models.Orders;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IOrderProvider
{
    Task<IReadOnlyCollection<OrderInfo>> GetOrdersAsync(
        string accountId,
        string symbol,
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<OrderInfo>> GetOpenOrdersAsync(
        CancellationToken cancellationToken = default);

    Task<IReadOnlyCollection<OrderInfo>> GetOrdersAsync(
        string symbol,
        CancellationToken cancellationToken = default);
}