using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.UpdateRiskPerTrade;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class UpdateRiskPerTradeCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<UpdateRiskPerTradeCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateRiskPerTradeCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.UpdateRiskPerTrade(
            command.RiskPerTrade);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}