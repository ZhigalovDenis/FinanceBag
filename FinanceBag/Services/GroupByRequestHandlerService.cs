using FinanceBag.ViewModel;

namespace FinanceBag.Services
{
    public class GroupByRequestHandlerService : IGroupByRequestHandlerService<List<GroupByMonthViewModel>>
    {
        private List<GroupByMonthViewModel> listGroupByNameViewModels = new List<GroupByMonthViewModel>();    

        /// <summary>
        /// Экспорт данных во ViewModel 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task</*GroupByNameViewModel*/List<GroupByMonthViewModel>> ExportToVM(IEnumerable<dynamic> data)
        {
           return await Task.Run(() => 
           {
               foreach (var item in data)
                {
                   GroupByMonthViewModel groupByNameViewModel = new GroupByMonthViewModel();
                   groupByNameViewModel.vM_Date = item.Date;
                   groupByNameViewModel.vM_Cost = item.Cost;
                   listGroupByNameViewModels.Add(groupByNameViewModel);
               }

               return listGroupByNameViewModels;

            });
            
        }
    }
}
