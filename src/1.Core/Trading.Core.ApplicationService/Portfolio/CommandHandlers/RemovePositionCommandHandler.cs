using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Portfolio;
using Trading.Core.RequestResponse.Portfolio.Commands.RemovePosition;

namespace Trading.Core.ApplicationService.Portfolio.CommandHandlers;

public sealed class RemovePositionCommandHandler(
    BaseServices baseServices,
    IPortfolioRepository repository)
    : CommandHandler<RemovePositionCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        RemovePositionCommand command,
        CancellationToken cancellationToken)
    {
        var portfolio = await repository.GetAsync(
            command.PortfolioId,
            cancellationToken);

        if (portfolio is null)
            return Result(ApplicationServiceStatus.NotFound);

        portfolio.RemovePosition(command.PositionId);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}