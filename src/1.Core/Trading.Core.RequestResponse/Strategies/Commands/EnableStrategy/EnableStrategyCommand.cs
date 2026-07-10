using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Strategies.Commands.EnableStrategy;

public sealed class EnableStrategyCommand : ICommand
{
    public BaseEntityId StrategyId { get; init; } = default!;
}