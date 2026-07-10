namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateRiskPerTrade;

public sealed class UpdateRiskPerTradeCommandValidator
    : AbstractValidator<UpdateRiskPerTradeCommand>
{
    public UpdateRiskPerTradeCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();

        RuleFor(x => x.RiskPerTrade)
            .GreaterThan(0);
    }
}