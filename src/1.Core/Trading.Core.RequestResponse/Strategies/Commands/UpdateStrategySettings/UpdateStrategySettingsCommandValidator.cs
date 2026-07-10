namespace Trading.Core.RequestResponse.Strategies.Commands.UpdateStrategySettings;

public sealed class UpdateStrategySettingsCommandValidator
    : AbstractValidator<UpdateStrategySettingsCommand>
{
    public UpdateStrategySettingsCommandValidator()
    {
        RuleFor(x => x.StrategyId)
            .NotNull();

        RuleFor(x => x.TimeFrame)
            .NotEmpty();

        RuleFor(x => x.RiskPercent)
            .GreaterThan(0);

        RuleFor(x => x.RiskReward)
            .GreaterThan(0);

        RuleFor(x => x.MaxOpenPositions)
            .GreaterThan(0);
    }
}