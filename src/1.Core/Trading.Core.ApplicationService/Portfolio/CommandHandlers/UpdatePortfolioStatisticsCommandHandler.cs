using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Portfolio;
using Trading.Core.RequestResponse.Portfolio.Commands.UpdatePortfolioStatistics;

namespace Trading.Core.ApplicationService.Portfolio.CommandHandlers;

public sealed class UpdatePortfolioStatisticsCommandHandler(
    BaseServices baseServices,
    IPortfolioRepository repository)
    : CommandHandler<UpdatePortfolioStatisticsCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdatePortfolioStatisticsCommand command,
        CancellationToken cancellationToken)
    {
        var portfolio = await repository.GetAsync(
            command.PortfolioId,
            cancellationToken);

        if (portfolio is null)
            return Result(ApplicationServiceStatus.NotFound);

        portfolio.UpdateStatistics(
            command.Balance,
            command.Equity,
            command.FloatingProfit,
            command.RealizedProfit);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}