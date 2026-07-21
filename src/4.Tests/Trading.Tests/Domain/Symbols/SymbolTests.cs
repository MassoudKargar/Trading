using Trading.Core.Domain.Symbols;

namespace Trading.Tests.Domain.Symbols;

public sealed class SymbolTests
{
    [Fact]
    public void Create_WithValidData_InitializesTradableSymbol()
    {
        var symbol = Symbol.Create("EURUSD", "EUR", "USD", 5, 0.00001m, 0.01m);

        Assert.Equal("EURUSD", symbol.Name);
        Assert.True(symbol.IsTradable);
        Assert.Equal(5, symbol.Digits);
    }

    [Fact]
    public void UpdateSpreadLotSizeAndTickSize_UpdatesValues()
    {
        var symbol = Symbol.Create("EURUSD", "EUR", "USD", 5, 0.00001m, 0.01m);

        symbol.UpdateSpread(0.0002m);
        symbol.UpdateLotSize(0.1m);
        symbol.UpdateTickSize(0.0001m);

        Assert.Equal(0.0002m, symbol.Spread);
        Assert.Equal(0.1m, symbol.LotSize);
        Assert.Equal(0.0001m, symbol.TickSize);
        Assert.NotNull(symbol.UpdatedAt);
    }

    [Fact]
    public void DisableTrading_MakesMarketClosed()
    {
        var symbol = Symbol.Create("EURUSD", "EUR", "USD", 5, 0.00001m, 0.01m);
        symbol.TradingHours.AddSession(new SymbolSession(
            DayOfWeek.Monday,
            new TimeOnly(0, 0),
            new TimeOnly(23, 59),
            true));

        symbol.DisableTrading();

        Assert.False(symbol.IsMarketOpen(new DateTime(2026, 7, 20, 12, 0, 0, DateTimeKind.Utc)));
    }

    [Fact]
    public void NormalizePrice_RoundsToConfiguredDigits()
    {
        var symbol = Symbol.Create("EURUSD", "EUR", "USD", 3, 0.001m, 0.01m);

        Assert.Equal(1.235m, symbol.NormalizePrice(1.23456m));
    }

    [Fact]
    public void NormalizeVolume_RoundsToLotSize()
    {
        var symbol = Symbol.Create("EURUSD", "EUR", "USD", 5, 0.00001m, 0.1m);

        Assert.Equal(1.2m, symbol.NormalizeVolume(1.23m));
    }
}
