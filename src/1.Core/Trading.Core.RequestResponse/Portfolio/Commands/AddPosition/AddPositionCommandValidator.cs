namespace Trading.Core.RequestResponse.Portfolio.Commands.AddPosition;

public sealed class AddPositionCommandValidator
    : AbstractValidator<AddPositionCommand>
{
    public AddPositionCommandValidator()
    {
        RuleFor(x => x.PortfolioId)
            .NotNull();

        RuleFor(x => x.PositionId)
            .NotNull();
    }
}