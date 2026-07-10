using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Portfolio.Commands.RemovePosition;

public sealed class RemovePositionCommand : ICommand
{
    public BaseEntityId PortfolioId { get; init; } = default!;

    public BaseEntityId PositionId { get; init; } = default!;
}