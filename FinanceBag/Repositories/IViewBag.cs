namespace FinanceBag.Repositories
{
    public interface IViewBag
    {
        Task<IEnumerable<dynamic>> GetListToViewBag();
    }
}
