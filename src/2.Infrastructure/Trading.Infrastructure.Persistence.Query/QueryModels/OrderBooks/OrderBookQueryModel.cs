using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.OrderBooks;

public sealed class OrderBookQueryModel
{
    public BaseEntityId Id { get; set; }

    public string Symbol { get; set; } = default!;

    public DateTime UpdatedAt { get; set; }

    public ICollection<OrderBookBidQueryModel> Bids { get; set; }
        = [];

    public ICollection<OrderBookAskQueryModel> Asks { get; set; }
        = [];
}

public sealed class OrderBookBidQueryModel
{
    public long Id { get; set; }

    public BaseEntityId OrderBookId { get; set; }

    public decimal Price { get; set; }

    public decimal Volume { get; set; }
}

public sealed class OrderBookAskQueryModel
{
    public long Id { get; set; }

    public BaseEntityId OrderBookId { get; set; }

    public decimal Price { get; set; }

    public decimal Volume { get; set; }
}