using Domain.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Mappings
{
    public class LowMapping : IEntityTypeConfiguration<LowEntity>
    {
        public void Configure(EntityTypeBuilder<LowEntity> builder)
        {
            builder.ToTable("Quote.Low");

            builder.HasKey(x => x.Id);


            builder.Property(entity => entity.Value)
               .HasColumnType("float").IsRequired(false);

            builder.Property(entity => entity.Date)
                 .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.TimeStamp)
                 .HasColumnType("int").IsRequired(false);

            builder.HasOne(x => x.Quote)
                .WithMany(entity => entity.Low)
                .HasForeignKey(x => x.QuoteId);
        }
    }
}