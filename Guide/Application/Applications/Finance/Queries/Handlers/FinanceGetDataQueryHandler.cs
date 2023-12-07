using Applications.Finance.Models;
using Applications.Interfaces.Repository;
using Domain;
using MediatR;

namespace Applications.Finance.Queries.Handlers
{
    public  class FinanceGetDataQueryHandler : IRequestHandler<FinanceGetDataQuery, Response>
    {
        private readonly IResponse _response;
        private readonly IMetaRepository _metaRepository;

        public FinanceGetDataQueryHandler(IResponse response, IMetaRepository metaRepository)
        {
            _response = response;
            _metaRepository = metaRepository;
        }

        public async Task<Response> Handle(FinanceGetDataQuery request, CancellationToken cancellationToken)
        {

            var meta = await _metaRepository.GetWithRelationshipAsync();
            
            var listResponse = new List<ResponseLastDays>();

            int day = 0;
            foreach (var item in meta.Quote.Open.OrderBy(x => x.Date))
            {
                if (day == 30)
                    break;

                var response = new ResponseLastDays();
            
                response.Data = item.Date.Value;
                response.Value = item.Value.Value;
                response.Day = day + 1;
                response.PercentComparedFistDate = await DifferenceBetweenTwoValues(meta.RegularMarketPrice.Value, meta.Quote.Open.OrderBy(x => x.Date).First().Value.Value);

                if (listResponse.Any())
                    response.Percent = await DifferenceBetweenTwoValues(listResponse.Last().Value, item.Value.Value);

                listResponse.Add(response);
                day++;
            }



            return await _response.CreateSuccessResponseAsync(listResponse, string.Empty);

        }

        private async Task<double> DifferenceBetweenTwoValues(float first, float second) 
        {
            return ((second - first) / Math.Abs(first)) * 100.0;

        }

    }
}
