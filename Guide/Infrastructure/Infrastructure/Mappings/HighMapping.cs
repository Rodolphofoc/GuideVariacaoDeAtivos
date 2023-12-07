using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class HighMapping : IEntityTypeConfiguration<HighEntity>
    {

        public void Configure(EntityTypeBuilder<HighEntity> builder)
        {
            builder.ToTable("Quote.High");

            builder.HasKey(x => x.Id);


            builder.Property(entity => entity.Value)
               .HasColumnType("float").IsRequired(false);


            builder.Property(entity => entity.Date)
                 .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.TimeStamp)
                 .HasColumnType("int").IsRequired(false);

            builder.HasOne(x => x.Quote)
                .WithMany(entity => entity.High)
                .HasForeignKey(x => x.QuoteId);
        }
    }
}
