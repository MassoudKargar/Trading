namespace Trading.Core.RequestResponse.RiskManagement.Commands.AddRiskRule;

public sealed class AddRiskRuleCommandValidator
    : AbstractValidator<AddRiskRuleCommand>
{
    public AddRiskRuleCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .NotEmpty()
            .MaximumLength(500);
    }
}