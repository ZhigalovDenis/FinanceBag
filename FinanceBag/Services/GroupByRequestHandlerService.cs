using FinanceBag.ViewModel;

namespace FinanceBag.Services
{
    public class GroupByRequestHandlerService : IGroupByRequestHandlerService<GroupByNameViewModel>
    {
        private List<string> Date = new List<string>();
        private List<decimal> Cost = new List<decimal>();

        /// <summary>
        /// Экспорт данных во ViewModel 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<GroupByNameViewModel> ExportToVM(IEnumerable<dynamic> data)
        {
           return await Task.Run(() => 
           {
                foreach (var item in data)
                {
                    Date.Add(item.Date);
                    Cost.Add(item.Cost);
                }
                GroupByNameViewModel groupByNameViewModel = new GroupByNameViewModel();

                groupByNameViewModel.vM_Date = Date;
                groupByNameViewModel.vM_Cost = Cost;
                return groupByNameViewModel;
            });
            
        }
    }
}
