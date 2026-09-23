using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.OrderBooks;
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

        builder.OwnsMany(x => x.Bids, bids =>
        {
            bids.WithOwner();

            bids.Property<long>("Id");
            bids.HasKey("Id");

            bids.Property(x => x.Price)
                .HasColumnName("Price")
                .HasPrecision(18, 8)
                .IsRequired();

            bids.Property(x => x.Volume)
                .HasColumnName("Volume")
                .HasPrecision(18, 8)
                .IsRequired();

            bids.ToTable("OrderBookBids");
        });

        builder.OwnsMany(x => x.Asks, asks =>
        {
            asks.WithOwner();

            asks.Property<long>("Id");
            asks.HasKey("Id");

            asks.Property(x => x.Price)
                .HasColumnName("Price")
                .HasPrecision(18, 8)
                .IsRequired();

            asks.Property(x => x.Volume)
                .HasColumnName("Volume")
                .HasPrecision(18, 8)
                .IsRequired();

            asks.ToTable("OrderBookAsks");
        });

        builder.HasIndex(x => x.Symbol)
            .IsUnique();
    }
}