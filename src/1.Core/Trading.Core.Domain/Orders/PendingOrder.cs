namespace Trading.Core.Domain.Orders;

public sealed class PendingOrder
{
    public PendingOrder(
        decimal triggerPrice,
        DateTime expiration)
    {
        TriggerPrice = triggerPrice;
        Expiration = expiration;
    }

    public decimal TriggerPrice { get; }

    public DateTime Expiration { get; }

    public bool IsExpired()
        => DateTime.UtcNow >= Expiration;
}