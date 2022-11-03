using FinanceBag.ViewModel;

namespace FinanceBag.Services
{
    public class GroupByRequestHandlerService : IGroupByRequestHandlerService<GroupByNameViewModel>
    {
        private List<string> Data = new List<string>();
        private List<decimal> Cost = new List<decimal>();

        /// <summary>
        /// Экспорт данных во ViewModel 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<GroupByNameViewModel> ExportToVM(IEnumerable<dynamic> data)
        {
            foreach (var item in data)
            {
                Data.Add(item.Date);
                Cost.Add(item.Cost);
            }
            GroupByNameViewModel groupByNameViewModel = new GroupByNameViewModel()
            {
                Date = data.Select(x => x.),
            };
            return  groupByNameViewModel;
        }
    }
}
