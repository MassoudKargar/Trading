using Trading.Core.Contracts.RiskManagement;
using Trading.Core.Domain.RiskManagement;
using Trading.Core.RequestResponse.RiskManagement.Commands.CreateRiskProfile;

namespace Trading.Core.ApplicationService.RiskManagement.CommandHandlers;

public sealed class CreateRiskProfileCommandHandler(
    BaseServices baseServices,
    IRiskProfileRepository repository)
    : CommandHandler<CreateRiskProfileCommand>(baseServices)
{
    public override async Task<CommandResult> Handle(
        CreateRiskProfileCommand command,
        CancellationToken cancellationToken)
    {
        var profile = new RiskProfile(
            command.Name,
            command.RiskPerTrade);

        await repository.InsertAsync(
            profile,
            cancellationToken);

        await repository.CommitAsync(
            cancellationToken);

        return Ok();
    }
}