using FinanceBag.Models;
using FinanceBag.Repositories;
using FinanceBag.ViewModel;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace FinanceBag.Controllers
{
    public class HomeController : Controller
    {
        

        private readonly IRepository<TypeOfActive, int> _typeOfActiveRepository;
        private readonly IRepository<Deal, int> _dealRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IRepository<Deal, int> dealRepository, IRepository<TypeOfActive, int> typeOfActiveRepository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _dealRepository = dealRepository;   
            _typeOfActiveRepository = typeOfActiveRepository;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<TypeOfActive> objTypeOfActiv = await _typeOfActiveRepository.GetAll();

            var dic  = new Dictionary<int, string>();    
            foreach (var item in objTypeOfActiv)
            {
                dic.Add(item.TypeOfActive_id, item.Type);
            }

             IEnumerable<Deal> objDeal = await _dealRepository.GetAll();


            
            var objFiltered  = objDeal.GroupBy(g => g.ISIN_id).Select(s => new
            {
                ISIN = s.Key,
                Type = s.Select(x => x.Actives.TypeOfActive_id).First(),
                Tiker = s.Select(x => x.Actives.Ticker).First(),
                Count = s.Sum(x => x.Count),
                Sum = s.Sum(x => x.Sum),
                Avg = s.Sum(x => x.Sum) / s.Sum(x => x.Count)
            }).OrderBy(x => x.Tiker).ToList();




            List<string> Ticker = new List<string>();
            List<string> ISIN = new List<string>();
            List<int> Count = new List<int>();
            List<string> Type = new List<string>();
            List<decimal> Sum = new List<decimal>();
            List<decimal> Avg = new List<decimal>();

           var val =  dic[1];

            foreach (var item in objFiltered)
            {
                Type.Add(dic[item.Type]);
                Ticker.Add(item.Tiker);
                ISIN.Add(item.ISIN);
                Count.Add(item.Count);
                Sum.Add(item.Sum);
                Avg.Add(item.Avg);
            }


            return View(objFiltered);




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