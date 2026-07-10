using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Strategies.Commands.StopStrategy;

public sealed class StopStrategyCommand : ICommand
{
    public BaseEntityId StrategyId { get; init; } = default!;
}