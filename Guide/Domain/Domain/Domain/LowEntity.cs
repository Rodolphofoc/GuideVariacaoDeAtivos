namespace Domain.Domain
{
    public class LowEntity : Entity
    {
        public float? Value { get; set; }

        public DateTime? Date { get; set; }

        public long? TimeStamp { get; set; }

        public virtual QuoteEntity Quote { get; set; }

        public int QuoteId { get; set; }
    }
}
