namespace Trading.Core.RequestResponse.Portfolio.Commands.AddTrade;

public sealed class AddTradeCommandValidator
    : AbstractValidator<AddTradeCommand>
{
    public AddTradeCommandValidator()
    {
        RuleFor(x => x.PortfolioId)
            .NotNull();

        RuleFor(x => x.TradeId)
            .NotNull();
    }
}