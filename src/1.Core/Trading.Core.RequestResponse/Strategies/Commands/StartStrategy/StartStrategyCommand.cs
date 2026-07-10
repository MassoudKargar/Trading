using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Strategies.Commands.StartStrategy;

public sealed class StartStrategyCommand : ICommand
{
    public BaseEntityId StrategyId { get; init; } = default!;
}