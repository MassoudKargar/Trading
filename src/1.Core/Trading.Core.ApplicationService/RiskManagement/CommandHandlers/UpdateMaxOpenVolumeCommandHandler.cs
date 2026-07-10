using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.UpdateMaxOpenVolume;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class UpdateMaxOpenVolumeCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<UpdateMaxOpenVolumeCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateMaxOpenVolumeCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.UpdateMaxOpenVolume(
            command.MaxOpenVolume);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}