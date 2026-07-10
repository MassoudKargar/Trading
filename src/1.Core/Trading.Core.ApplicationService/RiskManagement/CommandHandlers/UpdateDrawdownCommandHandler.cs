using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.UpdateDrawdown;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class UpdateDrawdownCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<UpdateDrawdownCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateDrawdownCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.UpdateDrawdown(
            command.MaxDrawdown);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}