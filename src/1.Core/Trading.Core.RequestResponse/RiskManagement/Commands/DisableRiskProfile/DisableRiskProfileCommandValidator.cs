namespace Trading.Core.RequestResponse.RiskManagement.Commands.DisableRiskProfile;

public sealed class DisableRiskProfileCommandValidator
    : AbstractValidator<DisableRiskProfileCommand>
{
    public DisableRiskProfileCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();
    }
}