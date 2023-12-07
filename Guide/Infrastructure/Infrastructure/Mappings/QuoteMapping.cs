using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class QuoteMapping : IEntityTypeConfiguration<QuoteEntity>
    {
        public void Configure(EntityTypeBuilder<QuoteEntity> builder)
        {
            builder.ToTable("Quote");

            builder.HasKey(entity => entity.Id);

            //builder.HasOne(quote => quote.Meta)
            //    .WithOne(meta => meta.Quote)
            //    .HasForeignKey<QuoteEntity>(quote => quote.MetaId);
        }

    }
}
