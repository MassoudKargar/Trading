using Trading.Core.Domain.Symbols;
using Trading.Core.Resources.Shared.Base;

namespace Trading.Core.Contracts.Data.Commands;

public interface ISymbolRepository
    : ICommandRepository<Symbol, BaseEntityId>
{
}