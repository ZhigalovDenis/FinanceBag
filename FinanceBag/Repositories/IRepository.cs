namespace FinanceBag.Repositories
{
    public interface IRepository<T>
    {
      
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(T id);
        Task Create(T entity);

        Task Delete(T entity);

        Task<T> Update(T entity);
    }
}

