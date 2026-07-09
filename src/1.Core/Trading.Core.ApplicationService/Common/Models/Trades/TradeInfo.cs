namespace Trading.Core.ApplicationService.Common.Models.Trades;

public sealed record TradeInfo(
    string TradeId,
    string OrderId,
    string Symbol,
    OrderSide Side,
    decimal Price,
    decimal Volume,
    decimal Commission,
    string CommissionAsset,
    DateTime ExecutedAt);