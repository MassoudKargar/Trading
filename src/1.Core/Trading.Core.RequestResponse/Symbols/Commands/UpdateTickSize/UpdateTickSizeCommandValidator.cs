namespace Trading.Core.RequestResponse.Symbols.Commands.UpdateTickSize;

public sealed class UpdateTickSizeCommandValidator
    : AbstractValidator<UpdateTickSizeCommand>
{
    public UpdateTickSizeCommandValidator()
    {
        RuleFor(x => x.SymbolId)
            .NotNull();

        RuleFor(x => x.TickSize)
            .GreaterThan(0);
    }
}