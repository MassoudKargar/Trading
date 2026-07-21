using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Positions;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class PositionQueryConfiguration
    : QueryConfigurationBase<PositionQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<PositionQueryModel> builder)
    {
        builder.ToTable("Positions", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Broker)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.BrokerPositionId)
            .HasMaxLength(100);

        builder.Property(x => x.Volume)
            .HasPrecision(18, 8);

        builder.Property(x => x.EntryPrice)
            .HasPrecision(18, 8);

        builder.Property(x => x.CurrentPrice)
            .HasPrecision(18, 8);

        builder.Property(x => x.StopLoss)
            .HasPrecision(18, 8);

        builder.Property(x => x.TakeProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.GrossProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.Commission)
            .HasPrecision(18, 8);

        builder.Property(x => x.Swap)
            .HasPrecision(18, 8);

        builder.Property(x => x.NetProfit)
            .HasPrecision(18, 8);

        builder.HasIndex(x => x.AccountId);

        builder.HasIndex(x => x.PortfolioId);

        builder.HasIndex(x => x.OrderId);

        builder.HasIndex(x => x.StrategyId);

        builder.HasIndex(x => x.Symbol);

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.OpenedAt);
    }
}
