namespace Trading.Infrastructure.Persistence.Query.Common;

public class TradingQueryDbContext(DbContextOptions<TradingQueryDbContext> options)
    : BaseQueryDbContext(options);