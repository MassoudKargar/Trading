namespace Trading.Core.Domain.RiskManagement;

public sealed class RiskRule
{
    public RiskRule(
        string name,
        string description)
    {
        Name = name;
        Description = description;

        IsEnabled = true;
    }

    public string Name { get; }

    public string Description { get; }

    public bool IsEnabled { get; private set; }

    public void Enable()
    {
        IsEnabled = true;
    }

    public void Disable()
    {
        IsEnabled = false;
    }
}