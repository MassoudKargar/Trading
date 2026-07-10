using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Symbols.Commands.UpdateLotSize;

public sealed class UpdateLotSizeCommand : ICommand
{
    public BaseEntityId SymbolId { get; init; } = default!;

    public decimal LotSize { get; init; }
}