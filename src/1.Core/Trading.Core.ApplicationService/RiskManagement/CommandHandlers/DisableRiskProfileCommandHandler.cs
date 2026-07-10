using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.DisableRiskProfile;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class DisableRiskProfileCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<DisableRiskProfileCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        DisableRiskProfileCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.Disable();

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}