namespace Trading.Core.RequestResponse.Trades.Commands.CloseTrade;

public sealed class CloseTradeCommandValidator
    : AbstractValidator<CloseTradeCommand>
{
    public CloseTradeCommandValidator()
    {
        RuleFor(x => x.TradeId)
            .NotNull();

        RuleFor(x => x.ExitPrice)
            .GreaterThan(0);

        RuleFor(x => x.GrossProfit);

        RuleFor(x => x.Commission)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.Swap);
    }
}