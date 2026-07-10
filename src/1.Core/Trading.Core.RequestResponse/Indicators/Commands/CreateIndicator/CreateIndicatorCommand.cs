using Trading.Core.Resources.Enumerations;

namespace Trading.Core.RequestResponse.Indicators.Commands.CreateIndicator;

public sealed class CreateIndicatorCommand : ICommand
{
    public string Name { get; init; } = string.Empty;

    public IndicatorType Type { get; init; }
}