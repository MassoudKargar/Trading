using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Portfolio;
using Trading.Core.RequestResponse.Portfolio.Commands.AddTrade;

namespace Trading.Core.ApplicationService.Portfolio.CommandHandlers;

public sealed class AddTradeCommandHandler(
    BaseServices baseServices,
    IPortfolioRepository repository)
    : CommandHandler<AddTradeCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        AddTradeCommand command,
        CancellationToken cancellationToken)
    {
        var portfolio = await repository.GetAsync(
            command.PortfolioId,
            cancellationToken);

        if (portfolio is null)
            return Result(ApplicationServiceStatus.NotFound);

        portfolio.AddTrade(command.TradeId);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}