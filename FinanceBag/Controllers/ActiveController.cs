using FinanceBag.Data;
using FinanceBag.Models;
using FinanceBag.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceBag.Controllers
{
    public class ActiveController : Controller
    {
        private readonly IRepository<Active, string> _activeRepository;

        public ActiveController(IRepository<Active, string> activeRepository)
        {
            _activeRepository = activeRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Active> objActiv = await _activeRepository.GetAll();
            return View(objActiv);
        }

        //GET
        public  IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Active obj)
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
            if (IsAvilible == 0)
            {
                await _activeRepository.Insert(obj);
                await _activeRepository.Save();
                TempData["success"] = "Новая запись создана успешно";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("ISIN_id", $"Запись {obj.ISIN_id} уже существет");
                return View();
            }
        }

        //GET
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var AtciveFromDb = await _activeRepository.GetById(id);
            if (AtciveFromDb == null)
            {
                return NotFound();
            }
            return View(AtciveFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Active obj)
        {
            await _activeRepository.Edit(obj);
            await _activeRepository.Save();
            TempData["success"] = "Запись отредактирована";
            return RedirectToAction("Index");
        }

        //GET
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var AtciveFromDb = await _activeRepository.GetById(id);
            if (AtciveFromDb == null)
            {
                return NotFound();
            }
            return View(AtciveFromDb);
        }



        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(string? id)
        {
            await _activeRepository.Delete(id);
            await _activeRepository.Save();
            TempData["success"] = "Запись удалена";
            return RedirectToAction("Index");
        }
    }
}
