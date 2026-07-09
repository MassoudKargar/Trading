namespace Trading.Core.ApplicationService.Common.Models.Trading;

public sealed record TradingSessionInfo(string Symbol, bool IsOpen, DateTime OpenTime, DateTime CloseTime);