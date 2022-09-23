namespace FinanceBag.Repositories
{
    public interface IRepositoryAll<T1>
    {
      
        Task<IEnumerable<T1>> GetAll();

    }
}

