namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateDrawdown;

public sealed class UpdateDrawdownCommandValidator
    : AbstractValidator<UpdateDrawdownCommand>
{
    public UpdateDrawdownCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();

        RuleFor(x => x.MaxDrawdown)
            .GreaterThanOrEqualTo(0);
    }
}