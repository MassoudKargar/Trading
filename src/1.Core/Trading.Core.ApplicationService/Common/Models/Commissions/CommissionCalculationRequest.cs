namespace Trading.Core.ApplicationService.Common.Models.Commissions;

public sealed record CommissionCalculationRequest(
    string Symbol,
    decimal Price,
    decimal Quantity,
    OrderSide Side);
public sealed record CommissionCalculationResult(
    decimal Commission,
    string Asset);