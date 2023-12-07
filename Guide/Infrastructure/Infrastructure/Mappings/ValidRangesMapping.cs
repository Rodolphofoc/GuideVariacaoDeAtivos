using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class ValidRangesMapping : IEntityTypeConfiguration<ValidRangesEntity>
    {
        public void Configure(EntityTypeBuilder<ValidRangesEntity> builder)
        {
            builder.ToTable("ValidRanges");

            builder.HasKey(x => x.Id);


            builder.Property(entity => entity.Value)
               .HasColumnType("varchar(50)").IsRequired(false);


            builder.HasOne(x => x.Meta)
                 .WithMany(entity => entity.ValidRanges)
                 .HasForeignKey(x => x.MetaId);
        }
    }
}
