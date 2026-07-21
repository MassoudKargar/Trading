using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.RiskManagement;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class RiskProfileQueryConfiguration
    : QueryConfigurationBase<RiskProfileQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<RiskProfileQueryModel> builder)
    {
        builder.ToTable("RiskProfiles", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.RiskPerTrade)
            .HasPrecision(18, 8);

        builder.Property(x => x.MaxDailyLoss)
            .HasPrecision(18, 8);

        builder.Property(x => x.MaxDrawdown)
            .HasPrecision(18, 8);

        builder.Property(x => x.MaxOpenVolume)
            .HasPrecision(18, 8);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasIndex(x => x.IsEnabled);
    }
}
