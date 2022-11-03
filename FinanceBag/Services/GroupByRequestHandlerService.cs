using FinanceBag.ViewModel;

namespace FinanceBag.Services
{
    public class GroupByRequestHandlerService : IGroupByRequestHandlerService<GroupByNameViewModel>
    {
        public Task<GroupByNameViewModel> ExportToVM(IEnumerable<dynamic> data)
        {
            throw new NotImplementedException();
        }
    }
}
