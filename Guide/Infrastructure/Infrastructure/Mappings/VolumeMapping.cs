using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    internal class VolumeMapping :  IEntityTypeConfiguration<VolumeEntity>
    {
        public void Configure(EntityTypeBuilder<VolumeEntity> builder)
        {
            builder.ToTable("Quote.Volume");

            builder.HasKey(x => x.Id);


            builder.Property(entity => entity.Value)
               .HasColumnType("int").IsRequired(false);


            builder.Property(entity => entity.Date)
                 .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.TimeStamp)
                 .HasColumnType("int").IsRequired(false);

            builder.HasOne(x => x.Quote)
                .WithMany(entity => entity.Volume)
                .HasForeignKey(x => x.QuoteId);
        }
    }
}
