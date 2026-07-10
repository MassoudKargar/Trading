using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Strategies.Commands.DisableStrategy;

public sealed class DisableStrategyCommand : ICommand
{
    public BaseEntityId StrategyId { get; init; } = default!;
}