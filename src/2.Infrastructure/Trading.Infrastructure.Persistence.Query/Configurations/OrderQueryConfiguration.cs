using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Orders;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class OrderQueryConfiguration
    : QueryConfigurationBase<OrderQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<OrderQueryModel> builder)
    {
        builder.ToTable("Orders", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Broker)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.BrokerOrderId)
            .HasMaxLength(100);

        builder.Property(x => x.Volume)
            .HasPrecision(18, 8);

        builder.Property(x => x.Price)
            .HasPrecision(18, 8);

        builder.Property(x => x.FilledPrice)
            .HasPrecision(18, 8);

        builder.Property(x => x.FilledVolume)
            .HasPrecision(18, 8);

        builder.Property(x => x.StopLoss)
            .HasPrecision(18, 8);

        builder.Property(x => x.TakeProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.TriggerPrice)
            .HasPrecision(18, 8);

        builder.Property(x => x.Commission)
            .HasPrecision(18, 8);

        builder.Property(x => x.Swap)
            .HasPrecision(18, 8);

        builder.HasIndex(x => x.AccountId);

        builder.HasIndex(x => x.PortfolioId);

        builder.HasIndex(x => x.StrategyId);

        builder.HasIndex(x => x.Symbol);

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.BrokerOrderId);

        builder.HasIndex(x => new
        {
            x.Symbol,
            x.Status
        });

        builder.HasIndex(x => x.CreatedAt);
    }
}
