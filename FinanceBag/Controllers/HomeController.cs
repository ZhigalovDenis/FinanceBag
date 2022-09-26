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
        
        public HomeController(ISelectRepository repositorySelect, IRequestHandlerService<AnaliticsViewModel, TypeOfActive> requestHandlerService,
            IBaseRepository<TypeOfActive, int> typeOfActiveRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _typeOfActiveRepository = typeOfActiveRepository;
            _repositorySelect = repositorySelect;
            _requestHandlerService = requestHandlerService;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<TypeOfActive> objTypeOfActiv = await _typeOfActiveRepository.GetAll();
            IEnumerable<dynamic> objFiltered = await _repositorySelect.Selected();

            _requestHandlerService.ExToVM(objFiltered, objTypeOfActiv);


            //var dictionaryDB = new Dictionary<int, string>();
            //foreach (var item in objTypeOfActiv)
            //{
            //    dictionaryDB.Add(item.TypeOfActive_id, item.Type);
            //}


            var dyn = new AnaliticsViewModel();




            var allValue = new AnaliticsViewModel();


            //List<string> Ticker = new List<string>();
            //List<string> ISIN = new List<string>();
            //List<int> Count = new List<int>();
            //List<string> Type = new List<string>();
            //List<decimal> Sum = new List<decimal>();
            //List<decimal> Avg = new List<decimal>();


            //foreach (var item in objFiltered)
            //{
            //    Type.Add(dictionaryDB[item.Type]);
            //    Ticker.Add(item.Ticker);
            //    ISIN.Add(item.ISIN);
            //    Count.Add(item.Count);
            //    Sum.Add(item.Sum);
            //    Avg.Add(item.Avg);
            //}

            //allValue.vmType = Type;
            //allValue.vmTicker = Ticker;
            //allValue.vmISIN = ISIN; 

            return View(allValue);
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