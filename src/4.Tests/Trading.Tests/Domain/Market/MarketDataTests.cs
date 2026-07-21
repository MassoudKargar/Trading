using Trading.Core.Domain.Market;
using Trading.Core.Domain.OrderBooks;
using Trading.Core.Domain.Ticks;
using Trading.Core.Resources.Enumerations.Markets;

namespace Trading.Tests.Domain.Market;

public sealed class MarketDataTests
{
    [Fact]
    public void Tick_Last_ReturnsMidPrice()
    {
        var tick = new Tick("EURUSD", 1.1m, 1.2m);

        Assert.Equal(1.15m, tick.Last);
    }

    [Fact]
    public void Tick_Update_ChangesBidAskAndLast()
    {
        var tick = new Tick("EURUSD", 1.1m, 1.2m);

        tick.Update(1.2m, 1.4m);

        Assert.Equal(1.2m, tick.Bid);
        Assert.Equal(1.4m, tick.Ask);
        Assert.Equal(1.3m, tick.Last);
    }

    [Fact]
    public void Candle_UpdateAndClose_ChangesMarketValues()
    {
        var candle = new Candle("EURUSD", TimeFrame.M1, DateTime.UtcNow);
        var closeTime = DateTime.UtcNow.AddMinutes(1);

        candle.Update(1.2m, 1.0m, 1.15m, 100);
        candle.CloseCandle(closeTime);

        Assert.Equal(1.2m, candle.High);
        Assert.Equal(1.0m, candle.Low);
        Assert.Equal(1.15m, candle.Close);
        Assert.True(candle.IsClosed);
        Assert.Equal(closeTime, candle.CloseTime);
    }

    [Fact]
    public void OrderBook_BestBidAndBestAsk_ReturnTopOfBook()
    {
        var book = new OrderBook("EURUSD");

        book.SetBids([
            new MarketDepth(1.1m, 10),
            new MarketDepth(1.2m, 5)
        ]);
        book.SetAsks([
            new MarketDepth(1.4m, 10),
            new MarketDepth(1.3m, 5)
        ]);

        Assert.Equal(1.2m, book.BestBid!.Price);
        Assert.Equal(1.3m, book.BestAsk!.Price);
    }
}
