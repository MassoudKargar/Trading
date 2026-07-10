using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Portfolio.Commands.CreatePortfolio;

public sealed class CreatePortfolioCommand : ICommand
{
    public BaseEntityId AccountId { get; init; } = default!;
}