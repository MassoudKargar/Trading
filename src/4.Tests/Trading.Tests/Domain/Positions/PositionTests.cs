using Trading.Core.Domain.Positions;
using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Enumerations.Positions;

namespace Trading.Tests.Domain.Positions;

public sealed class PositionTests
{
    [Fact]
    public void Constructor_InitializesOpenPosition()
    {
        var position = new Position("EURUSD", OrderSide.Buy, 1, 1.1m);

        Assert.True(position.IsOpen());
        Assert.True(position.IsBuy());
        Assert.Equal(1.1m, position.CurrentPrice);
    }

    [Fact]
    public void UpdateProfit_ComputesNetProfit()
    {
        var position = new Position("EURUSD", OrderSide.Buy, 1, 1.1m);

        position.UpdateProfit(100, 5, 2);

        Assert.Equal(93, position.Profit.NetProfit);
    }

    [Fact]
    public void PartialClose_ReducesVolumeAndMarksPartiallyClosed()
    {
        var position = new Position("EURUSD", OrderSide.Buy, 2, 1.1m);

        position.PartialClose(0.5m);

        Assert.Equal(1.5m, position.Volume);
        Assert.Equal(PositionStatus.PartiallyClosed, position.Status);
    }

    [Fact]
    public void Close_SetsClosedStatusAndClosePrice()
    {
        var position = new Position("EURUSD", OrderSide.Sell, 1, 1.1m);

        position.Close(1.0m);

        Assert.True(position.IsClosed());
        Assert.Equal(1.0m, position.CurrentPrice);
        Assert.NotNull(position.ClosedAt);
    }

    [Fact]
    public void ActivateTrailingStop_EnablesTrailingStopAndSetsStopLoss()
    {
        var position = new Position("EURUSD", OrderSide.Buy, 1, 1.1m);

        position.ActivateTrailingStop(1.05m);

        Assert.True(position.IsTrailingStopEnabled);
        Assert.Equal(1.05m, position.StopLoss);
    }
}
