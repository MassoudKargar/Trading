namespace Trading.Core.RequestResponse.Trades.Commands.UpdateSwap;

public sealed class UpdateSwapCommandValidator
    : AbstractValidator<UpdateSwapCommand>
{
    public UpdateSwapCommandValidator()
    {
        RuleFor(x => x.TradeId)
            .NotNull();

        RuleFor(x => x.Swap);
    }
}