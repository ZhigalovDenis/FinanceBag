using FinanceBag.ViewModel;

namespace FinanceBag.Services
{
    public interface IGetLastPriceService<T>
    {
        Task<T> GetLastPrice(T model);
    }
}
