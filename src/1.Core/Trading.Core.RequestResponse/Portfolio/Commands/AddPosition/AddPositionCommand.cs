using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Portfolio.Commands.AddPosition;

public sealed class AddPositionCommand : ICommand
{
    public BaseEntityId PortfolioId { get; init; } = default!;

    public BaseEntityId PositionId { get; init; } = default!;
}