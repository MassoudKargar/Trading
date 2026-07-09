namespace Trading.Core.RequestResponse.Trades.Commands.UpdateCommission;

public sealed class UpdateCommissionCommandValidator
    : AbstractValidator<UpdateCommissionCommand>
{
    public UpdateCommissionCommandValidator()
    {
        RuleFor(x => x.TradeId)
            .NotNull();

        RuleFor(x => x.Commission)
            .GreaterThanOrEqualTo(0);
    }
}