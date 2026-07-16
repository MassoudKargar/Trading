using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Positions;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class PositionConfiguration
    : ConfigurationBase<Position>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Position> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.AccountId)
            .IsRequired();

        builder.Property(x => x.PortfolioId)
            .IsRequired();

        builder.Property(x => x.OrderId)
            .IsRequired();

        builder.Property(x => x.StrategyId);

        builder.Property(x => x.Broker)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(x => x.BrokerPositionId)
            .HasMaxLength(100);

        builder.Property(x => x.MagicNumber);

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Side)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.Volume)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.EntryPrice)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.CurrentPrice)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.StopLoss)
            .HasPrecision(18, 8);

        builder.Property(x => x.TakeProfit)
            .HasPrecision(18, 8);

        builder.Property(x => x.IsTrailingStopEnabled)
            .IsRequired();

        builder.Property(x => x.OpenedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.Property(x => x.ClosedAt);

        builder.OwnsOne(x => x.Profit, profit =>
        {
            profit.Property(x => x.GrossProfit)
                .HasPrecision(18, 8);

            profit.Property(x => x.Commission)
                .HasPrecision(18, 8);

            profit.Property(x => x.Swap)
                .HasPrecision(18, 8);

            profit.Ignore(x => x.NetProfit);
        });

        builder.HasIndex(x => x.AccountId);

        builder.HasIndex(x => x.PortfolioId);

        builder.HasIndex(x => x.OrderId);

        builder.HasIndex(x => x.StrategyId);

        builder.HasIndex(x => x.Symbol);

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.BrokerPositionId);

        builder.HasIndex(x => new
        {
            x.Symbol,
            x.Status
        });

        builder.HasIndex(x => x.OpenedAt);
    }
}