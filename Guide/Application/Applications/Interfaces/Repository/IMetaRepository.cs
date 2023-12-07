using Domain.Domain;

namespace Applications.Interfaces.Repository
{
    public interface IMetaRepository : IRepository<MetaEntity>
    {
        Task<MetaEntity> GetWithRelationshipAsync();
    }
}
