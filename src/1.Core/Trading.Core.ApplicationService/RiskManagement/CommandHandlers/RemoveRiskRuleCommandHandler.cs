using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.RemoveRiskRule;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class RemoveRiskRuleCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<RemoveRiskRuleCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        RemoveRiskRuleCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.RemoveRule(
            command.Name);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}