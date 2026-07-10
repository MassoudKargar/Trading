namespace Trading.Core.RequestResponse.Symbols.Commands.EnableTrading;

public sealed class EnableTradingCommandValidator
    : AbstractValidator<EnableTradingCommand>
{
    public EnableTradingCommandValidator()
    {
        RuleFor(x => x.SymbolId)
            .NotNull();
    }
}