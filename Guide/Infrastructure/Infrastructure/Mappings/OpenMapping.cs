using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class OpenMapping : IEntityTypeConfiguration<OpenEntity>
    {
        public void Configure(EntityTypeBuilder<OpenEntity> builder)
        {
            builder.ToTable("Quote.Open");

            builder.HasKey(x => x.Id);

            builder.Property(entity => entity.Value)
               .HasColumnType("float");


            builder.Property(entity => entity.Date)
                 .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.TimeStamp)
                 .HasColumnType("int").IsRequired(false);

            builder.HasOne(x => x.Quote)
                .WithMany(entity => entity.Open)
                .HasForeignKey(x => x.QuoteId);
        }
    }
}
