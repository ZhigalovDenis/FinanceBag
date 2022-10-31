namespace FinanceBag.Repositories
{
    public interface IGropupRepository<T> 
    {
        Task<IEnumerable<T>> GroupByMonth();
    }
}

