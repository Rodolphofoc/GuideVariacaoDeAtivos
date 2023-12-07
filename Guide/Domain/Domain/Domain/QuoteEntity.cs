namespace Domain.Domain
{
    public class QuoteEntity : Entity
    {
        public ICollection<CloseEntity> Close { get; set; } = new List<CloseEntity>();
        public ICollection<LowEntity> Low { get; set; } = new List<LowEntity>();
        public ICollection<OpenEntity> Open { get; set; } = new List<OpenEntity>();
        public ICollection<HighEntity> High { get; set; } = new List<HighEntity>();
        public ICollection<VolumeEntity> Volume { get; set; } = new List<VolumeEntity>();
        public virtual MetaEntity Meta { get; set; }
        public int MetaId { get; set; }

    }
}
