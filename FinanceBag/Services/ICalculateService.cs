namespace FinanceBag.Services
{
    public interface ICalculateService<T>
    {
        Task<T> CalculateProfit(T model);
    }
}
