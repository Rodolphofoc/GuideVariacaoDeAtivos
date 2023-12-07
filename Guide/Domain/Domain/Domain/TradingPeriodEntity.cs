namespace Domain.Domain
{
    public class TradingPeriodEntity : Entity
    {
        public string? Timezone { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? Gmtoffset { get; set; }

        public virtual MetaEntity MetaEntity { get; set; }

        public int MetaId { get; set; }
    }
}
