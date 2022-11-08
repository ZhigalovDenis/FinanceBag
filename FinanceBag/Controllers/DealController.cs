using FinanceBag.Data;
using FinanceBag.Models;
using FinanceBag.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceBag.Controllers
{
    public class DealController : Controller
    {
        private readonly IBaseRepository<Active, string> _activeRepository;
        private readonly IBaseRepository<Deal, int> _dealRepository;
        private readonly IFilterRepository<Deal> _filterRepository;

        public DealController(IBaseRepository<Active, string> activeRepository, IBaseRepository<Deal, int> dealRepository,
            IFilterRepository<Deal> filterRepository)
        {
            _activeRepository = activeRepository;
            _dealRepository = dealRepository;
            _filterRepository = filterRepository;
        }

        private async void ActivesList()
        {
            IEnumerable<Active> objActiv = await _activeRepository.GetAll();
            ViewBag.ISIN_id = objActiv.Select(s => s.ISIN_id);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string value0, string value1)
        {
            if(value0 == null && value1 == null)
            {
                IEnumerable<Deal> objDeal = await _dealRepository.GetAll();
                return View(objDeal);
            }
            IEnumerable<Deal> objDeal1 = await _filterRepository.FilterBy(value0, value1);
            return View(objDeal1);
        }

        //GET
        public IActionResult Create()
        {
            ActivesList();
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Deal obj)
        {
            byte IsAvilible = 0;
            IEnumerable<Active> objActiv = await _activeRepository.GetAll();
            foreach (var item in objActiv)
            {
                if (item.ISIN_id == obj.ISIN_id.Trim(' ', '\t'))
                {
                    IsAvilible = 1;
                    break;
                }
            }
            if (IsAvilible == 1)
            {
            obj.Sum = obj.Count * obj.Price;
            await _dealRepository.Insert(obj);
            await _dealRepository.Save();
            TempData["success"] = "Новая запись создана успешно";
            return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("ISIN_id", $"Запись {obj.ISIN_id} не существует");
                ActivesList();
                return View();
            }
        }

        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            ActivesList();
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var DealFromDb = await _dealRepository.GetById((int)id);
            if (DealFromDb == null)
            {
                return NotFound();
            }
            return View(DealFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Deal obj)
        {
            byte IsAvilible = 0;
            IEnumerable<Active> objActiv = await _activeRepository.GetAll();
            foreach (var item in objActiv)
            {
                if (item.ISIN_id == obj.ISIN_id.Trim(' ', '\t'))
                {
                    IsAvilible = 1;
                    break;
                }
            }
            if (IsAvilible == 1)
            {
                obj.Sum = obj.Count * obj.Price;
                await _dealRepository.Edit(obj);
                await _dealRepository.Save();
                TempData["success"] = "Запись отредактирована";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("ISIN_id", $"Запись {obj.ISIN_id} не существует");
                ActivesList();
                return View();
            }
        }

        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var DealFromDb = await _dealRepository.GetById((int)id);
            if (DealFromDb == null)
            {
                return NotFound();
            }
            return View(DealFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _dealRepository.Delete(id);
            await _dealRepository.Save();
            TempData["success"] = "Запись удалена";
            return RedirectToAction("Index");
        }

    }
}
