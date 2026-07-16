using Trading.Core.Domain.Symbols;

namespace Trading.Core.Contracts.Symbols;

public interface ISymbolRepository
    : ICommandRepository<Symbol, BaseEntityId>
{
}