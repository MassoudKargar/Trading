namespace Trading.Core.RequestResponse.Symbols.Commands.CreateSymbol;

public sealed class CreateSymbolCommand : ICommand
{
    public string Name { get; init; } = string.Empty;

    public string BaseCurrency { get; init; } = string.Empty;

    public string QuoteCurrency { get; init; } = string.Empty;

    public int Digits { get; init; }

    public decimal TickSize { get; init; }

    public decimal LotSize { get; init; }
}