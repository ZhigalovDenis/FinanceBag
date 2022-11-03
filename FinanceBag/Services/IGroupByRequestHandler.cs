namespace FinanceBag.Services
{
    public interface IGroupByRequestHandler<T>
    {
        Task<T> ExportToVM(IEnumerable<dynamic> data);
    }
}
