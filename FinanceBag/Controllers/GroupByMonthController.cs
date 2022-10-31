using FinanceBag.Models;
using FinanceBag.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBag.Controllers
{
    public class GroupByMonthController : Controller
    {
        private readonly IGroupRepository _repositoryGroup;

        public GroupByMonthController(IGroupRepository repositoryGroup)
        {
            _repositoryGroup = repositoryGroup;
        }
        public async Task<IActionResult> Index()
        {
            var objGroupByMonth = await _repositoryGroup.GroupByMonth();
            return View(objGroupByMonth);
        }
    }
}
