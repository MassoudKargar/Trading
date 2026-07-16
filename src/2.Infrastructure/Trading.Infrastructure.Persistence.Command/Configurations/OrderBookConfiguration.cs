using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.OrderBooks;
using Trading.Infrastructure.Persistence.Command.Common;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class OrderBookConfiguration
    : ConfigurationBase<OrderBook>
{
    protected override void ConfigureEntity(EntityTypeBuilder<OrderBook> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.Ignore(x => x.BestBid);

        builder.Ignore(x => x.BestAsk);

        builder.OwnsMany(x => x.Bids, bids =>
        {
            bids.ToTable("OrderBookBids", Schema.Trading);

            bids.WithOwner()
                .HasForeignKey("OrderBookId");

            bids.Property<long>("Id");

            bids.HasKey("Id");

            bids.Property(x => x.Price)
                .HasPrecision(18, 8)
                .IsRequired();

            bids.Property(x => x.Volume)
                .HasPrecision(18, 8)
                .IsRequired();

            bids.HasIndex(x => x.Price);
        });

        builder.OwnsMany(x => x.Asks, asks =>
        {
            asks.ToTable("OrderBookAsks", Schema.Trading);

            asks.WithOwner()
                .HasForeignKey("OrderBookId");

            asks.Property<long>("Id");

            asks.HasKey("Id");

            asks.Property(x => x.Price)
                .HasPrecision(18, 8)
                .IsRequired();

            asks.Property(x => x.Volume)
                .HasPrecision(18, 8)
                .IsRequired();

            asks.HasIndex(x => x.Price);
        });

        builder.HasIndex(x => x.Symbol)
            .IsUnique();

        builder.HasIndex(x => x.UpdatedAt);
    }
}