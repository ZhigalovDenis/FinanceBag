namespace FinanceBag.Repositories
{
    public interface IFilterRepository<T>
    {
        Task<IEnumerable<T>> ByISIN(string search);
    }
}
