namespace Trading.Core.RequestResponse.RiskManagement.Commands.UpdateMaxOpenVolume;

public sealed class UpdateMaxOpenVolumeCommandValidator
    : AbstractValidator<UpdateMaxOpenVolumeCommand>
{
    public UpdateMaxOpenVolumeCommandValidator()
    {
        RuleFor(x => x.RiskProfileId)
            .NotNull();

        RuleFor(x => x.MaxOpenVolume)
            .GreaterThanOrEqualTo(0);
    }
}