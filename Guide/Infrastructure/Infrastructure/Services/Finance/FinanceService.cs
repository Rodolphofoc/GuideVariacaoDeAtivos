using Applications.Finance.Models;
using Applications.Interfaces.Service;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Services.Finance
{
    public class FinanceService : IFinanceService 
    {
        private readonly IConfiguration _configuration;

        private string url;

        public FinanceService(IConfiguration configuration)
        {
            _configuration = configuration;
            this.url = _configuration.GetSection("EndPointFinance").Value;
        }

        public async Task<ResponseFinance> GetDataFinance()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var financeResponse = JsonConvert.DeserializeObject<ResponseFinance>(content);

                    return financeResponse;
                }
                else
                {
                    throw new Exception("Erro na api");
                }
            }
        }
    }
}
