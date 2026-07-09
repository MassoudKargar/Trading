using Trading.Core.ApplicationService.Common.Models.Accounts;
using Trading.Core.Domain.Enumerations.Orders;

namespace Trading.Core.ApplicationService.Common.Models.Risks;

public sealed record RiskCheckRequest(
    string Symbol,
    OrderSide Side,
    decimal Price,
    decimal Quantity,
    AccountInfo Account);