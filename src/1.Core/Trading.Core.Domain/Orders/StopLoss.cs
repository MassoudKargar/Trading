namespace Trading.Core.Domain.Orders;

public sealed class StopLoss
{
    public StopLoss(decimal price)
    {
        if (price <= 0)
            throw new ArgumentOutOfRangeException(nameof(price));

        Price = price;
    }

    public decimal Price { get; }

    public StopLoss Move(decimal newPrice)
        => new(newPrice);
}