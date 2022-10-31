using FinanceBag.Models;
using FinanceBag.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBag.Controllers
{
    public class GroupByMonthController : Controller
    {
        private readonly IBaseRepository<Deal, int> _dealRepository;

        public GroupByMonthController(IBaseRepository<Deal, int> dealRepository)
        {
            _dealRepository = dealRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Deal> objDeal = await _dealRepository.GetAll();
            return View(objDeal);
        }
    }
}
