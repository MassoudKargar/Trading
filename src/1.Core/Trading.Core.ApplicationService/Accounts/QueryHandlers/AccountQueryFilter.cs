namespace Trading.Core.ApplicationService.Accounts.QueryHandlers;



public class AccountQueryFilter()
    : PagedSortableQueryFilter<AccountQueryFilter.SortAccountPropertyNames>(new SortAccountPropertyNames()),
        IQuery<PagedCollectionQueryResult<GetAllAccountQueryResult>>,
        IQuery<GetAccountByIdQueryResult>,
        IQuery<GetAccountBalanceQueryResult>,
        IQuery<GetAccountMarginQueryResult>,
        IQuery<GetAccountLeverageQueryResult>
{
    public class SortAccountPropertyNames : ISortablePropertyCollection
    {
        public const string AccountId = "AccountId";
        public const string Provider = "Provider";
        public const string AccountNumber = "AccountNumber";
        public const string Currency = "Currency";
        public const string Balance = "Balance";
        public const string Equity = "Equity";
        public const string CreatedAt = "CreatedAt";

        public string GetDefault()
        {
            return AccountId;
        }
    }

    public long? AccountId { get; set; }

    public string? Provider { get; set; }

    public string? AccountNumber { get; set; }

    public string? Currency { get; set; }

    public bool? IsActive { get; set; }

    public int? Leverage { get; set; }

    public decimal? MinBalance { get; set; }

    public decimal? MaxBalance { get; set; }
}