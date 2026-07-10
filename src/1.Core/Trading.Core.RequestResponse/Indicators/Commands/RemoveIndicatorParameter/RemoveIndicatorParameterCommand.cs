using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Indicators.Commands.RemoveIndicatorParameter;

public sealed class RemoveIndicatorParameterCommand : ICommand
{
    public BaseEntityId IndicatorId { get; init; } = default!;

    public string Name { get; init; } = string.Empty;
}