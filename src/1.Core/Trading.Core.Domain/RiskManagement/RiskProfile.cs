using Trading.Core.Domain.Events.RiskManagement;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Domain.RiskManagement;

public sealed class RiskProfile : AggregateRoot<BaseEntityId>
{
    private readonly List<RiskRule> _rules = [];

    public RiskProfile(
        string name,
        decimal riskPerTrade)
    {
        Id = BaseEntityId.New();
        Name = name;
        RiskPerTrade = riskPerTrade;

        IsEnabled = true;

        CreatedAt = DateTime.UtcNow;
        AddEvent(new RiskProfileCreatedEvent(
            Id,
            Name,
            RiskPerTrade));
    }

    public string Name { get; private set; } = default!;

    public decimal RiskPerTrade { get; private set; }

    public decimal MaxDailyLoss { get; private set; }

    public decimal MaxDrawdown { get; private set; }

    public decimal MaxOpenVolume { get; private set; }

    public int MaxOpenPositions { get; private set; }

    public bool IsEnabled { get; private set; }

    public IReadOnlyCollection<RiskRule> Rules
        => _rules.AsReadOnly();

    public DateTime CreatedAt { get; }

    public DateTime? UpdatedAt { get; private set; }

    public void UpdateRiskPerTrade(decimal value)
    {
        RiskPerTrade = value;
        UpdatedAt = DateTime.UtcNow;
        AddEvent(new RiskPerTradeChangedEvent(
            Id,
            value));
    }

    public void UpdateDailyLoss(decimal value)
    {
        MaxDailyLoss = value;
        UpdatedAt = DateTime.UtcNow;
        AddEvent(new MaxDailyLossChangedEvent(
            Id,
            value));

    }

    public void UpdateDrawdown(decimal value)
    {
        MaxDrawdown = value;
        UpdatedAt = DateTime.UtcNow;
        AddEvent(new MaxDrawdownChangedEvent(
            Id,
            value));
    }

    public void UpdateMaxOpenVolume(decimal value)
    {
        MaxOpenVolume = value;
        UpdatedAt = DateTime.UtcNow;
        AddEvent(new MaxOpenVolumeChangedEvent(
            Id,
            value));
    }

    public void UpdateMaxOpenPositions(int value)
    {
        MaxOpenPositions = value;
        UpdatedAt = DateTime.UtcNow;
        AddEvent(new MaxOpenPositionsChangedEvent(
            Id,
            value));
    }

    public void AddRule(RiskRule rule)
    {
        _rules.Add(rule);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new RiskRuleAddedEvent(
            Id,
            rule.Name));
    }

    public void RemoveRule(string name)
    {
        _rules.RemoveAll(x => x.Name == name);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new RiskRuleRemovedEvent(
            Id,
            name));
    }

    public void Enable()
    {
        IsEnabled = true;

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new RiskProfileEnabledEvent(Id));
    }

    public void Disable()
    {
        IsEnabled = false;

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new RiskProfileDisabledEvent(Id));
    }
}