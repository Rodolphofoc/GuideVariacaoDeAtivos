
namespace Domain.Domain
{
    public class MetaEntity : Entity
    {
        public string? Currency { get; set; }
        public string? Symbol { get; set; }
        public string? ExchangeName { get; set; }
        public string? InstrumentType { get; set; }
        public DateTime? FirstTradeDate { get; set; }
        public DateTime? RegularMarketTime { get; set; }
        public int? Gmtoffset { get; set; }
        public string? Timezone { get; set; }
        public string? ExchangeTimezoneName { get; set; }
        public float? RegularMarketPrice { get; set; }
        public float? ChartPreviousClose { get; set; }
        public float? PreviousClose { get; set; }
        public int? Scale { get; set; }
        public int? PriceHint { get; set; }
        public ICollection<CurrentTradingPeriodEntity> CurrentTradingPeriod { get; set; } = new List<CurrentTradingPeriodEntity>();
        public ICollection<TradingPeriodEntity> TradingPeriods { get; set; } = new List<TradingPeriodEntity>();
        public string? DataGranularity { get; set; }
        public string? Range { get; set; }
        public ICollection<ValidRangesEntity> ValidRanges { get; set; } = new List<ValidRangesEntity>();

        public virtual QuoteEntity Quote { get; set; } = new QuoteEntity();

    }
}
