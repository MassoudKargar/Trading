using Trading.Core.Domain.Symbols;

namespace Trading.Tests.Domain.Symbols;

public sealed class TradingHoursTests
{
    [Fact]
    public void IsMarketOpen_WhenSessionContainsUtcTime_ReturnsTrue()
    {
        var tradingHours = new TradingHours();
        tradingHours.AddSession(new SymbolSession(
            DayOfWeek.Monday,
            new TimeOnly(9, 0),
            new TimeOnly(17, 0),
            true));

        var result = tradingHours.IsMarketOpen(new DateTime(2026, 7, 20, 12, 0, 0, DateTimeKind.Utc));

        Assert.True(result);
    }

    [Fact]
    public void IsMarketOpen_WhenDayHasNoTradingSession_ReturnsFalse()
    {
        var tradingHours = new TradingHours();

        var result = tradingHours.IsMarketOpen(new DateTime(2026, 7, 20, 12, 0, 0, DateTimeKind.Utc));

        Assert.False(result);
    }
}
