using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.Portfolio;
using Trading.Core.RequestResponse.Portfolio.Commands.AddPosition;

namespace Trading.Core.ApplicationService.Portfolio.CommandHandlers;

public sealed class AddPositionCommandHandler(
    BaseServices baseServices,
    IPortfolioRepository repository)
    : CommandHandler<AddPositionCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        AddPositionCommand command,
        CancellationToken cancellationToken)
    {
        var portfolio = await repository.GetAsync(
            command.PortfolioId,
            cancellationToken);

        if (portfolio is null)
            return Result(ApplicationServiceStatus.NotFound);

        portfolio.AddPosition(command.PositionId);

        await repository.CommitAsync(cancellationToken);

        return Ok();
    }
}