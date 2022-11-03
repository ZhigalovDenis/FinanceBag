using FinanceBag.Models;

namespace FinanceBag.Services
{
    public interface IAnaliticsRequestHandlerService<T0, T1>
    { 
        Task<T0> ExToVM(IEnumerable<dynamic> data0, IEnumerable<T1> data1);
    }
}
