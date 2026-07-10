using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Indicators.Commands.UpdateIndicatorValue;

public sealed class UpdateIndicatorValueCommand : ICommand
{
    public BaseEntityId IndicatorId { get; init; } = default!;

    public decimal Value { get; init; }
}