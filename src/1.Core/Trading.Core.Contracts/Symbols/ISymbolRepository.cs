using Trading.Core.Domain.Symbols;

namespace Trading.Core.Contracts.Data.Commands;

public interface ISymbolRepository
    : ICommandRepository<Symbol, BaseEntityId>
{
}