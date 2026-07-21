using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Trading.Infrastructure.Persistence.Query.Configurations.Common;

public abstract class QueryConfigurationBase<TEntity>
    : IEntityTypeConfiguration<TEntity>
    where TEntity : class
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(
        EntityTypeBuilder<TEntity> builder);
}