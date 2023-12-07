using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class CurrentTradingPeriodMapping : IEntityTypeConfiguration<CurrentTradingPeriodEntity>
    {
        public void Configure(EntityTypeBuilder<CurrentTradingPeriodEntity> builder)
        {
            builder.ToTable("CurrentTradingPeriod");

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Type)
                .HasColumnType("varchar(10)").IsRequired(false);

            builder.Property(entity => entity.Timezone)
                .HasColumnType("varchar(10)").IsRequired(false);

            builder.Property(entity => entity.Start)
                .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.End)
                  .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.Gmtoffset)
                 .HasColumnType("int").IsRequired(false);

            builder.HasOne(x => x.Meta)
                .WithMany(entity => entity.CurrentTradingPeriod)
                .HasForeignKey(x => x.MetaId);

        }
    }
}
