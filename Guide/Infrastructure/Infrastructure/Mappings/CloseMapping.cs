using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class CloseMapping : IEntityTypeConfiguration<CloseEntity>
    {
        public void Configure(EntityTypeBuilder<CloseEntity> builder)
        {
            builder.ToTable("Quote.Close");

            builder.HasKey(x => x.Id);


            builder.Property(entity => entity.Value)
               .HasColumnType("decimal(5,2)").IsRequired(false);

            builder.HasOne(x => x.Quote)
                .WithMany(entity => entity.Close)
                .HasForeignKey(x => x.QuoteId);
        }

    }
}
