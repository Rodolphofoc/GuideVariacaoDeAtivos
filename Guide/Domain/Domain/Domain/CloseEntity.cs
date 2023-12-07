namespace Domain.Domain
{
    public class CloseEntity : Entity
    {
        public decimal? Value { get; set; }

        public virtual QuoteEntity Quote { get; set; }

        public int QuoteId {  get; set; }


    }
}
