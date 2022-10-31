namespace FinanceBag.Repositories
{
    public interface IGroupRepository
    {
        Task<IEnumerable<dynamic>> GroupByMonth();
    }
}

