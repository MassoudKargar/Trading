using Trading.Core.Domain.Events.Indicators;

namespace Trading.Core.Domain.Indicators;

public sealed class Indicator : AggregateRoot<BaseEntityId>
{
    private readonly List<IndicatorParameter> _parameters = [];

    public Indicator(
        string name,
        IndicatorType type)
    {
        Id = BaseEntityId.New();
        Name = name;
        Type = type;

        IsEnabled = true;

        CreatedAt = DateTime.UtcNow;
        AddEvent(new IndicatorCreatedEvent(
            Id,
            Name,
            Type));
    }

    public string Name { get; private set; } = default!;

    public IndicatorType Type { get; private set; }

    public bool IsEnabled { get; private set; }

    public IReadOnlyCollection<IndicatorParameter> Parameters
        => _parameters.AsReadOnly();

    public IndicatorValue? LastValue { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime? UpdatedAt { get; private set; }

    public void AddParameter(IndicatorParameter parameter)
    {
        _parameters.RemoveAll(x => x.Name == parameter.Name);

        _parameters.Add(parameter);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new IndicatorParameterAddedEvent(
            Id,
            parameter));
    }

    public void RemoveParameter(string name)
    {
        _parameters.RemoveAll(x => x.Name == name);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new IndicatorParameterRemovedEvent(
            Id,
            name));
    }

    public void UpdateValue(decimal value)
    {
        LastValue = new IndicatorValue(value);

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new IndicatorValueUpdatedEvent(
            Id,
            value));
    }

    public void Enable()
    {
        IsEnabled = true;

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new IndicatorEnabledEvent(Id));
    }

    public void Disable()
    {
        IsEnabled = false;

        UpdatedAt = DateTime.UtcNow;
        AddEvent(new IndicatorDisabledEvent(Id));
    }
}