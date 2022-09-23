using FinanceBag.Models;
using FinanceBag.Repositories;
using FinanceBag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinanceBag.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositoryAll<Deal> _allReposytory;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IRepositoryAll<Deal> allReposytory, ILogger<HomeController> logger)
        {
            _allReposytory = allReposytory;
            _logger = logger;
        }

       
        public async Task<IActionResult> Index()
        {
            AllTables objAll = new AllTables()
            {
                All = (List<Deal>)await _allReposytory.GetAll()
            }
            return View(objAll);
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}