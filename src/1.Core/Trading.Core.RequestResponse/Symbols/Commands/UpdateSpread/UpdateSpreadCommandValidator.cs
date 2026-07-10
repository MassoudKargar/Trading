namespace Trading.Core.RequestResponse.Symbols.Commands.UpdateSpread;

public sealed class UpdateSpreadCommandValidator
    : AbstractValidator<UpdateSpreadCommand>
{
    public UpdateSpreadCommandValidator()
    {
        RuleFor(x => x.SymbolId)
            .NotNull();

        RuleFor(x => x.Spread)
            .GreaterThanOrEqualTo(0);
    }
}