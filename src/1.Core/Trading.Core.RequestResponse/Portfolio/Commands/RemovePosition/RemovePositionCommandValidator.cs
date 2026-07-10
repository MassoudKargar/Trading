namespace Trading.Core.RequestResponse.Portfolio.Commands.RemovePosition;

public sealed class RemovePositionCommandValidator
    : AbstractValidator<RemovePositionCommand>
{
    public RemovePositionCommandValidator()
    {
        RuleFor(x => x.PortfolioId)
            .NotNull();

        RuleFor(x => x.PositionId)
            .NotNull();
    }
}