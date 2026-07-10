using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Indicators.Commands.EnableIndicator;

public sealed class EnableIndicatorCommand : ICommand
{
    public BaseEntityId IndicatorId { get; init; } = default!;
}