using Trading.Core.Domain.Accounts;
using Trading.Core.Domain.Orders;
using Trading.Core.Domain.Portfolio;
using Trading.Core.Domain.Positions;
using Trading.Core.Domain.RiskManagement;

namespace Trading.Tests.Domain.ValueObjects;

public sealed class ValueObjectTests
{
    [Fact]
    public void Leverage_WithNonPositiveValue_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Leverage(0));
    }

    [Fact]
    public void Margin_Total_ReturnsUsedPlusFree()
    {
        var margin = new Margin(100, 900);

        Assert.Equal(1_000, margin.Total);
    }

    [Fact]
    public void StopLoss_WithNonPositivePrice_Throws()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new StopLoss(0));
    }

    [Fact]
    public void PendingOrder_IsExpired_DependsOnExpiration()
    {
        var expired = new PendingOrder(1.1m, DateTime.UtcNow.AddSeconds(-1));
        var active = new PendingOrder(1.1m, DateTime.UtcNow.AddMinutes(1));

        Assert.True(expired.IsExpired());
        Assert.False(active.IsExpired());
    }

    [Fact]
    public void PositionPnL_NetProfitSubtractsCosts()
    {
        var pnl = new PositionPnL(100, 7, 3);

        Assert.Equal(90, pnl.NetProfit);
    }

    [Fact]
    public void PortfolioStatistics_TotalProfitAndMaxDrawdown_AreCalculated()
    {
        var statistics = new PortfolioStatistics(1_000, 1_050, 30, 20);

        statistics.UpdateDrawdown(5);
        statistics.UpdateDrawdown(3);

        Assert.Equal(50, statistics.TotalProfit);
        Assert.Equal(3, statistics.Drawdown);
        Assert.Equal(5, statistics.MaxDrawdown);
    }

    [Fact]
    public void Drawdown_Update_KeepsMaximum()
    {
        var drawdown = new Drawdown(1, 2);

        drawdown.Update(5);
        drawdown.Update(3);

        Assert.Equal(3, drawdown.Current);
        Assert.Equal(5, drawdown.Maximum);
    }
}
