using Trading.Core.ApplicationService.Orders.QueryHandlers;
using Trading.Core.Contracts.Orders.QueryResults;
using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Tests.Application.Orders;

public sealed class OrderQueryFilterExtensionsTests
{
    [Fact]
    public void ApplyFilter_FiltersBySymbolStatusTypeAndSide()
    {
        var matchingId = BaseEntityId.New();
        var orders = new[]
        {
            new GetAllOrderQueryResult
            {
                OrderId = matchingId,
                Symbol = "EURUSD",
                Status = OrderStatus.Accepted,
                OrderType = OrderType.Market,
                Side = OrderSide.Buy
            },
            new GetAllOrderQueryResult
            {
                OrderId = BaseEntityId.New(),
                Symbol = "BTCUSDT",
                Status = OrderStatus.Accepted,
                OrderType = OrderType.Market,
                Side = OrderSide.Buy
            },
            new GetAllOrderQueryResult
            {
                OrderId = BaseEntityId.New(),
                Symbol = "EURUSD",
                Status = OrderStatus.Cancelled,
                OrderType = OrderType.Limit,
                Side = OrderSide.Sell
            }
        }.AsQueryable();

        var result = orders.ApplyFilter(new OrderQueryFilter
        {
            Symbol = "EURUSD",
            Status = OrderStatus.Accepted,
            OrderType = OrderType.Market,
            Side = OrderSide.Buy
        }).ToList();

        var order = Assert.Single(result);
        Assert.Equal(matchingId, order.OrderId);
    }
}
