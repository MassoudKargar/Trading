using Trading.Core.Contracts.Portfolio;
using Trading.Core.RequestResponse.Portfolio.Commands.CreatePortfolio;

namespace Trading.Core.ApplicationService.Portfolio.CommandHandlers;

public sealed class CreatePortfolioCommandHandler(
    BaseServices baseServices,
    IPortfolioRepository repository)
    : CommandHandler<CreatePortfolioCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        CreatePortfolioCommand command,
        CancellationToken cancellationToken)
    {
        var portfolio = new Domain.Portfolio.Portfolio(command.AccountId);

        await repository.InsertAsync(portfolio, cancellationToken);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}