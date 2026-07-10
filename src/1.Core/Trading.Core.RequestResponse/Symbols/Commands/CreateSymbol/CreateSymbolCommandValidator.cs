namespace Trading.Core.RequestResponse.Symbols.Commands.CreateSymbol;

public sealed class CreateSymbolCommandValidator
    : AbstractValidator<CreateSymbolCommand>
{
    public CreateSymbolCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(x => x.BaseCurrency)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.QuoteCurrency)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Digits)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.TickSize)
            .GreaterThan(0);

        RuleFor(x => x.LotSize)
            .GreaterThan(0);
    }
}