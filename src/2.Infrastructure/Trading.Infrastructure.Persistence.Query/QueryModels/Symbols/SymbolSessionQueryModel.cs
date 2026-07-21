using Trading.Core.Resources.Shared.Base;

namespace Trading.Infrastructure.Persistence.Query.QueryModels.Symbols;

public sealed class SymbolSessionQueryModel
{
    public long Id { get; set; }

    public BaseEntityId SymbolId { get; set; }

    public DayOfWeek Day { get; set; }

    public TimeOnly OpenTime { get; set; }

    public TimeOnly CloseTime { get; set; }

    public bool IsTradingDay { get; set; }
}
