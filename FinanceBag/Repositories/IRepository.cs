namespace FinanceBag.Repositories
{
    public interface IRepository<T1, T2> where T1: class
    {
      
        Task<IEnumerable<T1>> GetAll();
        Task<T1> GetById(T2 id);
        Task<T1> Insert(T1 entity);
        Task<T1> Edit(T1 entity);
        Task Delete(T2 id);
        Task Save();
    }
}

