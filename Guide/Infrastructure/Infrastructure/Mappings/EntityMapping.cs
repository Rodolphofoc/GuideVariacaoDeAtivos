using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings
{
    public class EntityMapping<TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : Entity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            #region "Only for logging and audit propouse"

            builder.Ignore(e => e.CreatedAt);
            builder.Ignore(e => e.CreatedBy);
            builder.Ignore(e => e.LastModified);
            builder.Ignore(e => e.LastModifiedBy);

            #endregion "Only for logging and audit propouse"

            builder.Property(entity => entity.IntegrationId)
                .HasColumnType("uniqueidentifier")
                .HasDefaultValueSql("NewId()");

        }
    }
}
