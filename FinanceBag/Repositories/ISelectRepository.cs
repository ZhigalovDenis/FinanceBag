namespace FinanceBag.Repositories
{
    public interface ISelectRepository 
    {
        Task<IEnumerable<dynamic>> Selected();
    }
}

