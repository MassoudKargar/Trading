using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.Indicators;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class IndicatorConfiguration
    : ConfigurationBase<Indicator>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Indicator> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.Property(x => x.IsEnabled)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsOne(x => x.LastValue, lastValue =>
        {
            lastValue.Property(x => x.Value)
                .HasPrecision(18, 8);

            lastValue.Property(x => x.CalculatedAt);
        });

        builder.OwnsMany(x => x.Parameters, parameters =>
        {
            parameters.WithOwner();

            parameters.Property<long>("Id");
            parameters.HasKey("Id");

            parameters.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            parameters.Property(x => x.Value)
                .HasPrecision(18, 8)
                .IsRequired();

            parameters.ToTable("IndicatorParameters");
        });

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}