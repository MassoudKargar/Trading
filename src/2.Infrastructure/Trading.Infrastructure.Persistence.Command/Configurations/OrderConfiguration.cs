using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Orders;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class OrderConfiguration
    : ConfigurationBase<Order>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.AccountId)
            .IsRequired();

        builder.Property(x => x.PortfolioId)
            .IsRequired();

        builder.Property(x => x.StrategyId);

        builder.Property(x => x.Broker)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.BrokerOrderId)
            .HasMaxLength(100);

        builder.Property(x => x.MagicNumber);

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.OrderType)
            .IsRequired();

        builder.Property(x => x.Side)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.Volume)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.Price)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.FilledPrice)
            .HasPrecision(18, 8);

        builder.Property(x => x.FilledVolume)
            .HasPrecision(18, 8);

        builder.Property(x => x.Commission)
            .HasPrecision(18, 8);

        builder.Property(x => x.Swap)
            .HasPrecision(18, 8);

        builder.Property(x => x.TakeProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.SubmittedAt);

        builder.Property(x => x.AcceptedAt);

        builder.Property(x => x.FilledAt);

        builder.Property(x => x.CancelledAt);

        builder.Property(x => x.RejectedAt);

        builder.OwnsOne(x => x.StopLoss, stopLoss =>
        {
            stopLoss.Property(x => x.Price)
                .HasColumnName("StopLoss")
                .HasPrecision(18, 8);
        });

        builder.OwnsOne(x => x.PendingOrder, pending =>
        {
            pending.Property(x => x.TriggerPrice)
                .HasPrecision(18, 8);

            pending.Property(x => x.Expiration);
        });

        builder.HasIndex(x => x.AccountId);

        builder.HasIndex(x => x.PortfolioId);

        builder.HasIndex(x => x.StrategyId);

        builder.HasIndex(x => x.Symbol);

        builder.HasIndex(x => new
        {
            x.Symbol,
            x.Status
        });

        builder.HasIndex(x => x.BrokerOrderId);

        builder.HasIndex(x => x.CreatedAt);
    }
}