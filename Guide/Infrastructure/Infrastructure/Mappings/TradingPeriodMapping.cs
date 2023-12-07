using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class TradingPeriodMapping : IEntityTypeConfiguration<TradingPeriodEntity>
    {
        public void Configure(EntityTypeBuilder<TradingPeriodEntity> builder)
        {
            builder.ToTable("TradingPeriod");

            builder.HasOne(x => x.MetaEntity)
                 .WithMany(entity => entity.TradingPeriods)
                 .HasForeignKey(x => x.MetaId);


            builder.Property(entity => entity.Timezone)
                .HasColumnType("varchar(10)").IsRequired(false);

            builder.Property(entity => entity.Start)
                .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.End)
                  .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.Gmtoffset)
                 .HasColumnType("int").IsRequired(false);

        }

    }
}
