namespace Trading.Core.ApplicationService.Common.Models.Orders;

public sealed record OrderExecutionResult(
    string OrderId,
    bool Success,
    string? Message);