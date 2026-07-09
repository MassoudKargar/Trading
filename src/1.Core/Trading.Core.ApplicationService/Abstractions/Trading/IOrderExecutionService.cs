using Trading.Core.ApplicationService.Common.Models.Orders;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface IOrderExecutionService
{
    Task<OrderExecutionResult> PlaceOrderAsync(
        PlaceOrderRequest request,
        CancellationToken cancellationToken = default);


    Task<bool> CancelOrderAsync(
        string orderId,
        CancellationToken cancellationToken = default);


    Task<bool> ModifyOrderAsync(
        string orderId,
        decimal? price,
        decimal? quantity,
        decimal? stopLoss,
        decimal? takeProfit,
        CancellationToken cancellationToken = default);
}