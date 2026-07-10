using Trading.Core.Contracts.Symbols.Queries;

namespace Trading.Core.ApplicationService.Symbols.QueryHandlers;

public sealed class SymbolQueryFilter()
    : PagedSortableQueryFilter<SymbolQueryFilter.SortSymbolPropertyNames>(new SortSymbolPropertyNames()),
        IQuery<PagedCollectionQueryResult<GetAllSymbolQueryResult>>,
        IQuery<GetSymbolByIdQueryResult>,
        IQuery<GetTradingHoursQueryResult>
{
    public sealed class SortSymbolPropertyNames : ISortablePropertyCollection
    {
        public const string SymbolId = nameof(SymbolId);
        public const string Name = nameof(Name);
        public const string BaseCurrency = nameof(BaseCurrency);
        public const string QuoteCurrency = nameof(QuoteCurrency);
        public const string CreatedAt = nameof(CreatedAt);

        public string GetDefault() => CreatedAt;
    }

    public BaseEntityId? SymbolId { get; set; }

    public string? Name { get; set; }

    public string? BaseCurrency { get; set; }

    public string? QuoteCurrency { get; set; }

    public bool? IsTradable { get; set; }
}