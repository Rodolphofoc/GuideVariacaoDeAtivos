namespace Domain.Domain
{
    public class ValidRangesEntity : Entity
    {
        public string? Value { get; set; }

        public virtual MetaEntity Meta { get; set; }

        public int MetaId { get; set; }
    }
}
