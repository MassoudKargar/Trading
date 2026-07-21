using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Trading.Infrastructure.Persistence.Query.Common;
using Trading.Infrastructure.Persistence.Query.Configurations.Common;
using Trading.Infrastructure.Persistence.Query.QueryModels.OrderBooks;

namespace Trading.Infrastructure.Persistence.Query.Configurations;

public sealed class OrderBookQueryConfiguration
    : QueryConfigurationBase<OrderBookQueryModel>
{
    protected override void ConfigureEntity(EntityTypeBuilder<OrderBookQueryModel> builder)
    {
        builder.ToTable("OrderBooks", Schema.Trading);

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Symbol)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.HasMany(x => x.Bids)
            .WithOne()
            .HasForeignKey(x => x.OrderBookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Asks)
            .WithOne()
            .HasForeignKey(x => x.OrderBookId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.Symbol)
            .IsUnique();

        builder.HasIndex(x => x.UpdatedAt);
    }
}
