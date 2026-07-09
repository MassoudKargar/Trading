using Trading.Core.ApplicationService.Common.Models.Symbols;

namespace Trading.Core.ApplicationService.Abstractions.Trading;

public interface ISymbolProvider
{
    Task<SymbolInfo?> GetSymbolAsync(
        string symbol,
        CancellationToken cancellationToken = default);


    Task<IReadOnlyCollection<SymbolInfo>> GetSymbolsAsync(
        CancellationToken cancellationToken = default);


    Task<IReadOnlyCollection<SymbolInfo>> GetTradingSymbolsAsync(
        CancellationToken cancellationToken = default);
    Task<TradingRulesInfo?> GetTradingRulesAsync(
        string symbol,
        CancellationToken cancellationToken = default);
}