using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Symbols.Commands.EnableTrading;

public sealed class EnableTradingCommand : ICommand
{
    public BaseEntityId SymbolId { get; init; } = default!;
}