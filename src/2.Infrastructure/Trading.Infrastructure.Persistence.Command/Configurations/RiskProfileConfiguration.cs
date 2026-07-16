using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Core.Domain.RiskManagement;
using Trading.Infrastructure.Persistence.Command.Configurations.Common;

namespace Trading.Infrastructure.Persistence.Command.Configurations;

public sealed class RiskProfileConfiguration
    : ConfigurationBase<RiskProfile>
{
    protected override void ConfigureEntity(EntityTypeBuilder<RiskProfile> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.RiskPerTrade)
            .HasPrecision(18, 8)
            .IsRequired();

        builder.Property(x => x.MaxDailyLoss)
            .HasPrecision(18, 8);

        builder.Property(x => x.MaxDrawdown)
            .HasPrecision(18, 8);

        builder.Property(x => x.MaxOpenVolume)
            .HasPrecision(18, 8);

        builder.Property(x => x.MaxOpenPositions)
            .IsRequired();

        builder.Property(x => x.IsEnabled)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.OwnsMany(x => x.Rules, rules =>
        {
            rules.WithOwner();

            rules.Property<long>("Id");
            rules.HasKey("Id");

            rules.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            rules.Property(x => x.Description)
                .HasMaxLength(500);

            rules.Property(x => x.IsEnabled)
                .IsRequired();

            rules.ToTable("RiskRules");
        });

        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}