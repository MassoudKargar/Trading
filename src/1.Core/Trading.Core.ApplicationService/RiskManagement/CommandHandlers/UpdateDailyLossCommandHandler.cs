using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.UpdateDailyLoss;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class UpdateDailyLossCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<UpdateDailyLossCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateDailyLossCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.UpdateDailyLoss(
            command.MaxDailyLoss);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}