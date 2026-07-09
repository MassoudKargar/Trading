namespace Trading.Core.RequestResponse.Trades.Commands.OpenTrade;

public sealed class OpenTradeCommandValidator
    : AbstractValidator<OpenTradeCommand>
{
    public OpenTradeCommandValidator()
    {
        RuleFor(x => x.PositionId)
            .NotNull();

        RuleFor(x => x.Symbol)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Volume)
            .GreaterThan(0);

        RuleFor(x => x.EntryPrice)
            .GreaterThan(0);
    }
}