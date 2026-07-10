namespace Trading.Core.RequestResponse.Symbols.Commands.DisableTrading;

public sealed class DisableTradingCommandValidator
    : AbstractValidator<DisableTradingCommand>
{
    public DisableTradingCommandValidator()
    {
        RuleFor(x => x.SymbolId)
            .NotNull();
    }
}