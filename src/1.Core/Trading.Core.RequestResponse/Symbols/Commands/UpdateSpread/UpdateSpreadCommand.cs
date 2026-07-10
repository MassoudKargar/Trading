using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Symbols.Commands.UpdateSpread;

public sealed class UpdateSpreadCommand : ICommand
{
    public BaseEntityId SymbolId { get; init; } = default!;

    public decimal Spread { get; init; }
}