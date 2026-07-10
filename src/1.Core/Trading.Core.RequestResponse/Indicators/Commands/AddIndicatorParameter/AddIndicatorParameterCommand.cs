using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Indicators.Commands.AddIndicatorParameter;

public sealed class AddIndicatorParameterCommand : ICommand
{
    public BaseEntityId IndicatorId { get; init; } = default!;

    public string Name { get; init; } = string.Empty;

    public decimal Value { get; init; }
}