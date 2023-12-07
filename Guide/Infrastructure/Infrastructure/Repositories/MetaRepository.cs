using Applications.Interfaces.Repository;
using Domain.Domain;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MetaRepository : Repository<MetaEntity>, IMetaRepository
    {
        private readonly GuideContext _context;

        public MetaRepository(GuideContext context) : base(context)
        { 
            _context = context;
        }


        public async Task<MetaEntity> GetWithRelationshipAsync()
        {
            var query = await _context.Meta
                .Include(q => q.Quote)
                .ThenInclude(quote => quote.Open)
                .OrderByDescending(x => x.Id).FirstOrDefaultAsync();

            return query;
        }
    }
}
