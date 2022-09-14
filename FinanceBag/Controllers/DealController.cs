using FinanceBag.Data;
using FinanceBag.Models;
using FinanceBag.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceBag.Controllers
{
    public class DealController : Controller
    {
        private readonly IRepository<Active, string> _activeRepository;
        private readonly IRepository<Deal, int> _dealRepository;

        public DealController(IRepository<Active, string> activeRepository, IRepository<Deal, int> dealRepository)
        {
            _activeRepository = activeRepository;
            _dealRepository = dealRepository;
        }

        private async void ActivesList()
        {
            IEnumerable<Active> objActiv = await _activeRepository.GetAll();
            ViewBag.ISIN_id = objActiv.Select(s => s.ISIN_id);
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Deal> objDeal = await _dealRepository.GetAll();
            return View(objDeal);
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

                obj.Sum = obj.Count * obj.Price;
                await _dealRepository.Insert(obj);
                await _dealRepository.Save();
                TempData["success"] = "Новая запись создана успешно";
                return RedirectToAction("Index");

        }

        ////GET
        //public async Task<IActionResult> Edit(string? id)
        //{
        //    TypeOfActivesList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var AtciveFromDb = await _activeRepository.GetById(id);
        //    if (AtciveFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(AtciveFromDb);
        //}

        ////POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Active obj)
        //{
        //    await _activeRepository.Edit(obj);
        //    await _activeRepository.Save();
        //    TempData["success"] = "Запись отредактирована";
        //    return RedirectToAction("Index");
        //}

        ////GET
        //public async Task<IActionResult> Delete(string? id)
        //{
        //    TypeOfActivesList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var AtciveFromDb = await _activeRepository.GetById(id);
        //    if (AtciveFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(AtciveFromDb);
        //}

        ////POST
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeletePOST(string? id)
        //{
        //    await _activeRepository.Delete(id);
        //    await _activeRepository.Save();
        //    TempData["success"] = "Запись удалена";
        //    return RedirectToAction("Index");
        //}
    }
}
