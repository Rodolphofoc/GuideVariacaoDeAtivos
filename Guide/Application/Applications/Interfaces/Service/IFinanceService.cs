using Applications.Finance.Models;

namespace Applications.Interfaces.Service
{
    public interface IFinanceService
    {
        Task<ResponseFinance> GetDataFinance();
    }
}
