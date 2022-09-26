using FinanceBag.Data;
using FinanceBag.Models;
using FinanceBag.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceBag.Controllers
{
    public class ActiveController : Controller
    {
        private readonly IBaseRepository<Active, string> _activeRepository;
        private readonly IBaseRepository<TypeOfActive, int> _typeOfActiveRepository;

        public ActiveController(IBaseRepository<Active, string> activeRepository, IBaseRepository<TypeOfActive, int> typeOfActiveRepository)
        {
            _activeRepository = activeRepository;
            _typeOfActiveRepository = typeOfActiveRepository;
        }

        private async void TypeOfActivesList()
        {
            IEnumerable<TypeOfActive> objTypeOfActiv = await _typeOfActiveRepository.GetAll();
            ViewBag.Type = objTypeOfActiv;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Active> objActiv = await _activeRepository.GetAll();
            return View(objActiv);
        }

        //GET
        public  IActionResult Create()
        {
            TypeOfActivesList();
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
                TypeOfActivesList();
                return View();
            }
        }

        //GET
        public async Task<IActionResult> Edit(string? id)
        {
            TypeOfActivesList();
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
            TypeOfActivesList();
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
