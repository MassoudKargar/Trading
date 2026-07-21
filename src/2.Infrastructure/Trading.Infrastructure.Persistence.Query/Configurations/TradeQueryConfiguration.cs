using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Trades;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class TradeQueryConfiguration
    : QueryConfigurationBase<TradeQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<TradeQueryModel> builder)
    {
        builder.ToTable("Trades", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Broker)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.BrokerTradeId)
            .HasMaxLength(100);

        builder.Property(x => x.Volume)
            .HasPrecision(18, 8);

        builder.Property(x => x.EntryPrice)
            .HasPrecision(18, 8);

        builder.Property(x => x.ExitPrice)
            .HasPrecision(18, 8);

        builder.Property(x => x.GrossProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.Commission)
            .HasPrecision(18, 8);

        builder.Property(x => x.Swap)
            .HasPrecision(18, 8);

        builder.Property(x => x.NetProfit)
            .HasPrecision(18, 8);

        builder.HasIndex(x => x.PositionId);

        builder.HasIndex(x => x.AccountId);

        builder.HasIndex(x => x.PortfolioId);

        builder.HasIndex(x => x.StrategyId);

        builder.HasIndex(x => x.Symbol);

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.EntryTime);

        builder.HasIndex(x => x.ExitTime);
    }
}
