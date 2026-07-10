namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateDailyLoss;

public sealed class UpdateDailyLossCommandValidator
    : AbstractValidator<UpdateDailyLossCommand>
{
    public UpdateDailyLossCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();

        RuleFor(x => x.MaxDailyLoss)
            .GreaterThanOrEqualTo(0);
    }
}