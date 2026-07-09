namespace Trading.Core.RequestResponse.Accounts.Commands.ChangeLeverage;

public sealed class ChangeLeverageCommand : ICommand
{
    public long AccountId { get; init; }

    public int Leverage { get; init; }
}