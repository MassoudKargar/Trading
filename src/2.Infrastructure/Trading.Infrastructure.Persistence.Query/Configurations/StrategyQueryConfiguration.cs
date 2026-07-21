using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Strategies;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class StrategyQueryConfiguration
    : QueryConfigurationBase<StrategyQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<StrategyQueryModel> builder)
    {
        builder.ToTable("Strategies", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.TimeFrame)
            .HasMaxLength(20);

        builder.Property(x => x.RiskPercent)
            .HasPrecision(18, 8);

        builder.Property(x => x.RiskReward)
            .HasPrecision(18, 8);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasIndex(x => x.Status);

        builder.HasIndex(x => x.IsEnabled);
    }
}
