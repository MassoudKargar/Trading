namespace Trading.Core.RequestResponse.RiskManagement.Commands.EnableRiskProfile;

public sealed class EnableRiskProfileCommandValidator
    : AbstractValidator<EnableRiskProfileCommand>
{
    public EnableRiskProfileCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();
    }
}