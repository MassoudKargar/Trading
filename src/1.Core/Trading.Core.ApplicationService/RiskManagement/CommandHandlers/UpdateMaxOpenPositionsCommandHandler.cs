using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.UpdateMaxOpenPositions;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class UpdateMaxOpenPositionsCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<UpdateMaxOpenPositionsCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        UpdateMaxOpenPositionsCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.UpdateMaxOpenPositions(
            command.MaxOpenPositions);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}