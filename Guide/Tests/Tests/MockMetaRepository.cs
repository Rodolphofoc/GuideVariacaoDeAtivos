using Applications.Interfaces.Repository;
using Domain.Domain;
using Moq;

namespace Tests
{
    public class MockMetaRepository
    {
        private MetaEntity metaEntity = new MetaEntity();


        public MockMetaRepository()
        {
            metaEntity = new MetaEntityBuilder().GetMeta();
        }

        public Mock<IMetaRepository> GetMockMetaRepository()
        {

            var mockRepository = new Mock<IMetaRepository>();


            mockRepository.Setup(x => x.GetWithRelationshipAsync()).ReturnsAsync(metaEntity);


            return mockRepository;

        }
    }
}
