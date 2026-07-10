using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Indicators.Commands.DisableIndicator;

public sealed class DisableIndicatorCommand : ICommand
{
    public BaseEntityId IndicatorId { get; init; } = default!;
}