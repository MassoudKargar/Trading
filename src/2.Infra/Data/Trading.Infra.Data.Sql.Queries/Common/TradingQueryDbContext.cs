namespace Trading.Infra.Data.Sql.Queries.Common;

public class TradingQueryDbContext(DbContextOptions<TradingQueryDbContext> options)
    : BaseQueryDbContext(options);