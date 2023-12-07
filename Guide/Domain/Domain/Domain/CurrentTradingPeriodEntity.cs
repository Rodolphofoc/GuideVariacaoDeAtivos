namespace Domain.Domain
{
    public class CurrentTradingPeriodEntity : Entity
    {
        public string? Type { get; set; }
        public string? Timezone { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public int? Gmtoffset { get; set; }
        public virtual MetaEntity Meta {  get; set; }
        public int MetaId { get;  set; }
    }
}
