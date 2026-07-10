namespace Trading.Core.RequestResponse.Symbols.Commands.UpdateLotSize;

public sealed class UpdateLotSizeCommandValidator
    : AbstractValidator<UpdateLotSizeCommand>
{
    public UpdateLotSizeCommandValidator()
    {
        RuleFor(x => x.SymbolId)
            .NotNull();

        RuleFor(x => x.LotSize)
            .GreaterThan(0);
    }
}