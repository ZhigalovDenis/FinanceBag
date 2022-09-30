using FinanceBag.Models;
using FinanceBag.Repositories;
using FinanceBag.Services;
using FinanceBag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Diagnostics;


namespace FinanceBag.Controllers
{
    public class HomeController : Controller
    {


        private readonly IBaseRepository<TypeOfActive, int> _typeOfActiveRepository;
        private readonly ILogger<HomeController> _logger;
        private readonly ISelectRepository _repositorySelect;
        private readonly IRequestHandlerService<AnaliticsViewModel, TypeOfActive> _requestHandlerService;
        private readonly IGetLastPriceService<AnaliticsViewModel> _getLastPriceService;
        
        public HomeController(IGetLastPriceService<AnaliticsViewModel> getLastPriceService, ISelectRepository repositorySelect, IRequestHandlerService<AnaliticsViewModel, TypeOfActive> requestHandlerService,
            IBaseRepository<TypeOfActive, int> typeOfActiveRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _typeOfActiveRepository = typeOfActiveRepository;
            _repositorySelect = repositorySelect;
            _requestHandlerService = requestHandlerService;
            _getLastPriceService = getLastPriceService;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<TypeOfActive> objTypeOfActiv = await _typeOfActiveRepository.GetAll();
            IEnumerable<dynamic> objFiltered = await _repositorySelect.Selected();

            AnaliticsViewModel analiticsViewModel = new AnaliticsViewModel();
            analiticsViewModel = await _requestHandlerService.ExToVM(objFiltered, objTypeOfActiv);
            analiticsViewModel  = await _getLastPriceService.GetLastPrice(analiticsViewModel);

            return View(analiticsViewModel);
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