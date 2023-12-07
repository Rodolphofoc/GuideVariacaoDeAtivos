using Applications.Finance.Queries;
using Applications.Finance.Queries.Handlers;
using Applications.Interfaces.Repository;
using Domain;
using FluentAssertions;
using Moq;

namespace Tests
{
    public class FinanceGetDataQueryHandlerTest
    {
        private readonly IResponse _response;
        private Mock<IMetaRepository> _metaRepository;

        public FinanceGetDataQueryHandlerTest()
        {
            _metaRepository = new MockMetaRepository().GetMockMetaRepository();
            _response = new Response();
        }

        [Fact]
        public async Task Should_Return_OK_Meta()
        {
            var query = new FinanceGetDataQuery();

            var handler = new FinanceGetDataQueryHandler(_response, _metaRepository.Object);

            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            result
                .Data
                .Should()
                .NotBeNull();

        }

    }
}