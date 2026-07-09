using Trading.Core.Domain.Enumerations.Strategy;
using Trading.Core.Domain.Events.Strategy;

namespace Trading.Core.Domain.Strategies;

public sealed class Strategy : AggregateRoot<BaseEntityId>
{

    public Strategy(
        string name,
        StrategyType type,
        StrategySettings settings)
    {
        Id = BaseEntityId.New();
        Name = name;
        Type = type;
        Settings = settings;

        IsEnabled = true;

        CreatedAt = DateTime.UtcNow;
        AddEvent(new StrategyCreatedEvent(
            Id,
            Name,
            Type));
    }

    public string Name { get; private set; } = default!;
    public StrategyStatus Status { get; private set; }

    public StrategyType Type { get; private set; }

    public StrategySettings Settings { get; private set; }

    public bool IsEnabled { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime? UpdatedAt { get; private set; }

    public void Enable()
    {
        IsEnabled = true;
        UpdatedAt = DateTime.UtcNow;
        AddEvent(new StrategyEnabledEvent(Id));
    }

    public void Disable()
    {
        IsEnabled = false;
        UpdatedAt = DateTime.UtcNow;
        AddEvent(new StrategyDisabledEvent(Id));
    }

    public void UpdateSettings(StrategySettings settings)
    {
        Settings = settings;
        UpdatedAt = DateTime.UtcNow;
        AddEvent(new StrategySettingsChangedEvent(
            Id,
            Settings));
    }
    public void Start()
    {
        Status = StrategyStatus.Running;

        AddEvent(new StrategyStartedEvent(Id));
    }


    public void Stop()
    {
        Status = StrategyStatus.Stopped;

        AddEvent(new StrategyStoppedEvent(Id));
    }
}