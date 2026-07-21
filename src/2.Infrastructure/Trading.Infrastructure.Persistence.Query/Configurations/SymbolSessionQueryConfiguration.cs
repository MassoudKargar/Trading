using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.Symbols;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class SymbolSessionQueryConfiguration
    : QueryConfigurationBase<SymbolSessionQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<SymbolSessionQueryModel> builder)
    {
        builder.ToTable("SymbolSessions", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Day)
            .IsRequired();

        builder.Property(x => x.OpenTime)
            .IsRequired();

        builder.Property(x => x.CloseTime)
            .IsRequired();

        builder.Property(x => x.IsTradingDay)
            .IsRequired();

        builder.HasIndex(x => x.SymbolId);
    }
}
