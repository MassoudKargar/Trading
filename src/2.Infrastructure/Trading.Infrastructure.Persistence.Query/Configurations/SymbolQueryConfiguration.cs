using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Symbols;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class SymbolQueryConfiguration
    : QueryConfigurationBase<SymbolQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<SymbolQueryModel> builder)
    {
        builder.ToTable("Symbols", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.BaseCurrency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.QuoteCurrency)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(x => x.TickSize)
            .HasPrecision(18, 8);

        builder.Property(x => x.LotSize)
            .HasPrecision(18, 8);

        builder.Property(x => x.Spread)
            .HasPrecision(18, 8);

        builder.Property(x => x.IsTradable)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt);

        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.HasIndex(x => x.IsTradable);
    }
}
