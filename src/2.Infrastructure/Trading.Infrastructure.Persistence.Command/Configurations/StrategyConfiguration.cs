using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Strategies;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class StrategyConfiguration
    : ConfigurationBase<Strategy>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Strategy> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.Status)
            .IsRequired();

        builder.Property(x => x.IsEnabled)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.Settings, settings =>
        {
            settings.Property(x => x.TimeFrame)
                .HasMaxLength(20)
                .IsRequired();

            settings.Property(x => x.RiskPercent)
                .HasPrecision(18, 8);

            settings.Property(x => x.RiskReward)
                .HasPrecision(18, 8);

            settings.Property(x => x.UseStopLoss);

            settings.Property(x => x.UseTakeProfit);

            settings.Property(x => x.AllowMultiplePositions);

            settings.Property(x => x.MaxOpenPositions);
        });

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}