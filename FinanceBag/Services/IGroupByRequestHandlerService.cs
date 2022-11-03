namespace FinanceBag.Services
{
    public interface IGroupByRequestHandlerService<T>
    {
        Task<T> ExportToVM(IEnumerable<dynamic> data);
    }
}
