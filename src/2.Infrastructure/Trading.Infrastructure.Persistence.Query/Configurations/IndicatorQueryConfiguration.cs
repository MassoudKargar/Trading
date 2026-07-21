using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Indicators;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class IndicatorQueryConfiguration
    : QueryConfigurationBase<IndicatorQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<IndicatorQueryModel> builder)
    {
        builder.ToTable("Indicators", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.LastValue)
            .HasPrecision(18, 8);

        builder.Property(x => x.IsEnabled)
            .IsRequired();

        builder.HasIndex(x => x.Name);

        builder.HasIndex(x => x.Type);

        builder.HasIndex(x => x.IsEnabled);
    }
}
