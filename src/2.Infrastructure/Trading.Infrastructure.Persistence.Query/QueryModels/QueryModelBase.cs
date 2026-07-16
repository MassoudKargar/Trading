using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels;

public abstract class QueryModelBase
{
    public BaseEntityId Id { get; set; }
}