namespace FinanceBag.Repositories
{
    public interface IFilterRepository<T>
    {
        Task<IEnumerable<T>> FilterBy(string value0, string value1);
    }
}
