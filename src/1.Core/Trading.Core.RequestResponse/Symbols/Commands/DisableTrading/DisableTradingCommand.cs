using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Symbols.Commands.DisableTrading;

public sealed class DisableTradingCommand : ICommand
{
    public BaseEntityId SymbolId { get; init; } = default!;
}