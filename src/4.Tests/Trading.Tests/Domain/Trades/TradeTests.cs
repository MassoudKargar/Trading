using Trading.Core.Domain.Trades;
using Trading.Core.Resources.Enumerations.Orders;
using Trading.Core.Resources.Enumerations.Trades;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Tests.Domain.Trades;

public sealed class TradeTests
{
    [Fact]
    public void Constructor_InitializesOpenTrade()
    {
        var trade = CreateTrade();

        Assert.Equal(TradeStatus.Open, trade.Status);
        Assert.Equal("EURUSD", trade.Symbol);
        Assert.Equal(1.1m, trade.EntryPrice);
    }

    [Fact]
    public void Close_WithPositiveNetProfit_MarksTradeProfitable()
    {
        var trade = CreateTrade();

        trade.Close(1.2m, 100, 5, 2);

        Assert.Equal(TradeStatus.Closed, trade.Status);
        Assert.Equal(93, trade.NetProfit);
        Assert.True(trade.IsProfit());
        Assert.False(trade.IsLoss());
        Assert.NotNull(trade.ExitTime);
    }

    [Fact]
    public void CalculateProfit_UsesGrossProfitMinusCosts()
    {
        var trade = CreateTrade();

        trade.UpdateCommission(3);
        trade.UpdateSwap(2);
        trade.CalculateProfit();

        Assert.Equal(-5, trade.NetProfit);
        Assert.True(trade.IsLoss());
    }

    private static Trade CreateTrade()
        => new(BaseEntityId.New(), "EURUSD", OrderSide.Buy, 1, 1.1m);
}
