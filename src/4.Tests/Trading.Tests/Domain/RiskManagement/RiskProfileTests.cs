using Trading.Core.Domain.RiskManagement;

namespace Trading.Tests.Domain.RiskManagement;

public sealed class RiskProfileTests
{
    [Fact]
    public void Constructor_InitializesEnabledRiskProfile()
    {
        var profile = new RiskProfile("Default", 1);

        Assert.Equal("Default", profile.Name);
        Assert.Equal(1, profile.RiskPerTrade);
        Assert.True(profile.IsEnabled);
    }

    [Fact]
    public void UpdateMethods_SetRiskLimits()
    {
        var profile = new RiskProfile("Default", 1);

        profile.UpdateRiskPerTrade(2);
        profile.UpdateDailyLoss(5);
        profile.UpdateDrawdown(10);
        profile.UpdateMaxOpenVolume(3);
        profile.UpdateMaxOpenPositions(4);

        Assert.Equal(2, profile.RiskPerTrade);
        Assert.Equal(5, profile.MaxDailyLoss);
        Assert.Equal(10, profile.MaxDrawdown);
        Assert.Equal(3, profile.MaxOpenVolume);
        Assert.Equal(4, profile.MaxOpenPositions);
    }

    [Fact]
    public void AddAndRemoveRule_UpdatesRulesCollection()
    {
        var profile = new RiskProfile("Default", 1);

        profile.AddRule(new RiskRule("MaxLoss", "Limit daily loss"));
        profile.RemoveRule("MaxLoss");

        Assert.Empty(profile.Rules);
    }

    [Fact]
    public void DisableAndEnable_ToggleProfileState()
    {
        var profile = new RiskProfile("Default", 1);

        profile.Disable();
        Assert.False(profile.IsEnabled);

        profile.Enable();
        Assert.True(profile.IsEnabled);
    }
}
