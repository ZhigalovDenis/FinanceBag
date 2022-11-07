using FinanceBag.Repositories;
using FinanceBag.Services;
using FinanceBag.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBag.Controllers
{
    public class GroupByMonthController : Controller
    {
        private readonly IGroupRepository _repositoryGroup;
        private readonly IGroupByRequestHandlerService<List<GroupByMonthViewModel>> _groupByRequestHandler;

        public GroupByMonthController(IGroupRepository repositoryGroup, IGroupByRequestHandlerService<List<GroupByMonthViewModel>> groupByRequestHandler)
        {
            _repositoryGroup = repositoryGroup;
            _groupByRequestHandler = groupByRequestHandler;
        }
        public async Task<IActionResult> Index()
        {
            var objGroupByMonth = await _repositoryGroup.GroupByMonth();

            List<GroupByMonthViewModel> listGroupByMonthViewModels = new List<GroupByMonthViewModel>();
            listGroupByMonthViewModels = await _groupByRequestHandler.ExportToVM(objGroupByMonth);

            return View(listGroupByMonthViewModels);
            
        }
    }
}
