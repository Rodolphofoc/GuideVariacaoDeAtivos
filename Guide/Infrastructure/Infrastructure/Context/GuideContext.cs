using Domain.Domain;
using Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class GuideContext : DbContext
    {
        public GuideContext(DbContextOptions<GuideContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GuideContext).Assembly);

            var entityTypes = modelBuilder.Model
                                                        .GetEntityTypes()
                                                        .Where(t => typeof(Entity).IsAssignableFrom(t.ClrType));

            foreach (var entityType in entityTypes)
            {
                var configurationType = typeof(EntityMapping<>)
                    .MakeGenericType(entityType.ClrType);

                modelBuilder
                    .ApplyConfiguration((dynamic)Activator.CreateInstance(configurationType));
            }


        }
        public DbSet<MetaEntity> Meta { get; set; }

        public DbSet<CurrentTradingPeriodEntity> CurrentTradingPeriodEntity { get; set; }

        //public DbSet<QuoteEntity> Quote { get; set; }

        public DbSet<ValidRangesEntity> ValidRanges { get; set; }

        public DbSet<TradingPeriodEntity> TradingPeriodEntity { get; set; }

    }
}
