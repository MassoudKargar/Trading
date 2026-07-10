namespace Trading.Core.RequestResponse.RiskManagement.Commands.CreateRiskProfile;

public sealed class CreateRiskProfileCommandValidator
    : AbstractValidator<CreateRiskProfileCommand>
{
    public CreateRiskProfileCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.RiskPerTrade)
            .GreaterThan(0);
    }
}