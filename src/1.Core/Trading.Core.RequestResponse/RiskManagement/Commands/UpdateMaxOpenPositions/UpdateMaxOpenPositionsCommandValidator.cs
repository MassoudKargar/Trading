namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateMaxOpenPositions;

public sealed class UpdateMaxOpenPositionsCommandValidator
    : AbstractValidator<UpdateMaxOpenPositionsCommand>
{
    public UpdateMaxOpenPositionsCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();

        RuleFor(x => x.MaxOpenPositions)
            .GreaterThan(0);
    }
}