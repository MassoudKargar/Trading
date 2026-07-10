using Base.Core.RequestResponse.Common;

using Trading.Core.Contracts.RiskManagement;
using Trading.Core.Domain.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.AddRiskRule;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class AddRiskRuleCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<AddRiskRuleCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        AddRiskRuleCommand command,
        CancellationToken cancellationToken)
    {
        var profile = await repository.GetAsync(
            command.RiskProfileId,
            cancellationToken);

        if (profile is null)
            return Result(ApplicationServiceStatus.NotFound);

        profile.AddRule(
            new RiskRule(
                command.Name,
                command.Description));

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}