using FinanceBag.Models;
using FinanceBag.Repositories;
using FinanceBag.Services;
using FinanceBag.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBag.Controllers
{
    public class GroupByMonthController : Controller
    {
        private readonly IGroupRepository _repositoryGroup;
        private readonly IGroupByRequestHandlerService<GroupByNameViewModel> _groupByRequestHandler;

        public GroupByMonthController(IGroupRepository repositoryGroup, IGroupByRequestHandlerService<GroupByNameViewModel> groupByRequestHandler)
        {
            _repositoryGroup = repositoryGroup;
            _groupByRequestHandler = groupByRequestHandler;
        }
        public async Task<IActionResult> Index()
        {
            var objGroupByMonth = await _repositoryGroup.GroupByMonth();

            GroupByNameViewModel groupByNameViewModel = new GroupByNameViewModel();
            groupByNameViewModel = await _groupByRequestHandler.ExportToVM(objGroupByMonth);
            return View(groupByNameViewModel);
        }
    }
}
