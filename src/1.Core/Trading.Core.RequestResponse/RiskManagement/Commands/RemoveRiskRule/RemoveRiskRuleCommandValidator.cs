using FluentValidation;

namespace Trading.Core.RequestResponse.RiskManagement.Commands.RemoveRiskRule;

public sealed class RemoveRiskRuleCommandValidator
    : AbstractValidator<RemoveRiskRuleCommand>
{
    public RemoveRiskRuleCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(100);
    }
}