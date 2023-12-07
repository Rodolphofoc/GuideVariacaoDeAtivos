using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class MetaMapping : IEntityTypeConfiguration<MetaEntity>
    {
        public void Configure(EntityTypeBuilder<MetaEntity> builder)
        {
            builder.ToTable("Meta");

            builder.HasKey(entity => entity.Id);

            builder.Property(entity => entity.Currency).HasColumnType("varchar(50)").IsRequired(false);

            builder.Property(entity => entity.Symbol)
           .HasColumnType("varchar(50)").IsRequired(false);

            builder.Property(entity => entity.ExchangeName)
                .HasColumnType("varchar(100)").IsRequired(false);

            builder.Property(entity => entity.FirstTradeDate)
             .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.RegularMarketTime)
             .HasColumnType("datetime").IsRequired(false);

            builder.Property(entity => entity.Gmtoffset)
                   .HasColumnType("int").IsRequired(false);

            builder.Property(entity => entity.Timezone)
                 .HasColumnType("varchar(100)").IsRequired(false);

            builder.Property(entity => entity.ExchangeTimezoneName)
                .HasColumnType("varchar(100)").IsRequired(false);

            builder.Property(entity => entity.RegularMarketPrice)
                .HasColumnType("decimal(5,2)").IsRequired(false);

            builder.Property(entity => entity.ChartPreviousClose)
               .HasColumnType("decimal(5,2)").IsRequired(false);

            builder.Property(entity => entity.PreviousClose)
               .HasColumnType("decimal(5,2)").IsRequired(false);

            builder.Property(entity => entity.Scale)
               .HasColumnType("int").IsRequired(false);

            builder.Property(entity => entity.PriceHint)
               .HasColumnType("int").IsRequired(false);
        }

    }
}
