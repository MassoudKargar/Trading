using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Portfolio.Commands.AddTrade;

public sealed class AddTradeCommand : ICommand
{
    public BaseEntityId PortfolioId { get; init; } = default!;

    public BaseEntityId TradeId { get; init; } = default!;
}