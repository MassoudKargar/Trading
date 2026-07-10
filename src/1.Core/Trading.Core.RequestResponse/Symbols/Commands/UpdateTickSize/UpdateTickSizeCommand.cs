using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.RequestResponse.Symbols.Commands.UpdateTickSize;

public sealed class UpdateTickSizeCommand : ICommand
{
    public BaseEntityId SymbolId { get; init; } = default!;

    public decimal TickSize { get; init; }
}