using Trading.Core.Domain.Indicators;
using Trading.Core.Resources.Enumerations;

namespace Trading.Tests.Domain.Indicators;

public sealed class IndicatorTests
{
    [Fact]
    public void Constructor_InitializesEnabledIndicator()
    {
        var indicator = new Indicator("RSI", IndicatorType.RSI);

        Assert.Equal("RSI", indicator.Name);
        Assert.True(indicator.IsEnabled);
        Assert.Empty(indicator.Parameters);
    }

    [Fact]
    public void AddParameter_ReplacesExistingParameterWithSameName()
    {
        var indicator = new Indicator("RSI", IndicatorType.RSI);

        indicator.AddParameter(new IndicatorParameter("Period", 14));
        indicator.AddParameter(new IndicatorParameter("Period", 21));

        var parameter = Assert.Single(indicator.Parameters);
        Assert.Equal("Period", parameter.Name);
        Assert.Equal(21, parameter.Value);
    }

    [Fact]
    public void UpdateValue_SetsLastValue()
    {
        var indicator = new Indicator("RSI", IndicatorType.RSI);

        indicator.UpdateValue(55.5m);

        Assert.NotNull(indicator.LastValue);
        Assert.Equal(55.5m, indicator.LastValue.Value);
    }

    [Fact]
    public void DisableAndEnable_ToggleIndicatorState()
    {
        var indicator = new Indicator("RSI", IndicatorType.RSI);

        indicator.Disable();
        Assert.False(indicator.IsEnabled);

        indicator.Enable();
        Assert.True(indicator.IsEnabled);
    }
}
