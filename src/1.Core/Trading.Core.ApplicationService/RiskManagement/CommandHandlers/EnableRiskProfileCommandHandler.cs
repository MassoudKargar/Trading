using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.EnableRiskProfile;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class EnableRiskProfileCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<EnableRiskProfileCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        EnableRiskProfileCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.Enable();

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}