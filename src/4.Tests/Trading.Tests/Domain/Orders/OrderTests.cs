using Trading.Core.Domain.Orders;
using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Tests.Domain.Orders;

public sealed class OrderTests
{
    [Fact]
    public void Constructor_InitializesPendingOrder()
    {
        var order = CreateOrder();

        Assert.Equal(OrderStatus.Pending, order.Status);
        Assert.Equal("EURUSD", order.Symbol);
        Assert.Equal(1.5m, order.Volume);
        Assert.Equal(1.1m, order.Price);
    }

    [Fact]
    public void SubmitAcceptExecute_MovesOrderToFilled()
    {
        var order = CreateOrder();

        order.Submit();
        order.Accept();
        order.Execute(1.12m);

        Assert.Equal(OrderStatus.Filled, order.Status);
        Assert.Equal(order.Volume, order.FilledVolume);
        Assert.Equal(1.12m, order.FilledPrice);
        Assert.NotNull(order.FilledAt);
    }

    [Fact]
    public void PartialFill_AccumulatesFilledVolume()
    {
        var order = CreateOrder();

        order.PartialFill(1.11m, 0.4m);
        order.PartialFill(1.12m, 0.3m);

        Assert.Equal(OrderStatus.PartiallyFilled, order.Status);
        Assert.Equal(0.7m, order.FilledVolume);
        Assert.Equal(1.12m, order.FilledPrice);
    }

    [Fact]
    public void Cancel_SetsCancelledStatus()
    {
        var order = CreateOrder();

        order.Cancel();

        Assert.Equal(OrderStatus.Cancelled, order.Status);
        Assert.NotNull(order.CancelledAt);
    }

    [Fact]
    public void SetStopLossAndTakeProfit_UpdatesRiskPrices()
    {
        var order = CreateOrder();

        order.SetStopLoss(1.0m);
        order.SetTakeProfit(1.2m);

        Assert.Equal(1.0m, order.StopLoss!.Price);
        Assert.Equal(1.2m, order.TakeProfit);
    }

    private static Order CreateOrder()
        => new(
            BaseEntityId.New(),
            BaseEntityId.New(),
            null,
            "Demo",
            "EURUSD",
            OrderType.Market,
            OrderSide.Buy,
            1.5m,
            1.1m);
}
