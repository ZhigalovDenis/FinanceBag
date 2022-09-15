
using FinanceBag.Models;
using FinanceBag.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBag.Controllers
{
    public class TypeOfActiveController : Controller
    {
        private readonly IRepository<TypeOfActive, int> _typeOfActiveRepository;

        public TypeOfActiveController(IRepository<TypeOfActive, int> typeOfActiveRepository)
        {
            _typeOfActiveRepository = typeOfActiveRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TypeOfActive> objTypeOfActiv = await _typeOfActiveRepository.GetAll();
            return View(objTypeOfActiv);

        }
        // GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeOfActive obj)
        {
            byte IsAvilible = 0;
            IEnumerable<TypeOfActive> objTypeOfActiv = await _typeOfActiveRepository.GetAll();
            foreach (var item in objTypeOfActiv)
            {
                if (item.Type == obj.Type.Trim(' ', '\t'))
                {
                    IsAvilible = 1;
                    break;
                }
            }
            if (IsAvilible == 0)
            {
                await _typeOfActiveRepository.Insert(obj);
                await _typeOfActiveRepository.Save();
                TempData["success"] = "Новая запись создана успешно";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Type", $"Запись {obj.Type} уже существет");
                return View();
            }
        }

        //GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var TypeOfAtciveFromDb = await _typeOfActiveRepository.GetById((int)id);
            if (TypeOfAtciveFromDb == null)
            {
                return NotFound();
            }
            return View(TypeOfAtciveFromDb);
        }

       // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TypeOfActive obj)
        {
                await _typeOfActiveRepository.Edit(obj);
                await _typeOfActiveRepository.Save();
                TempData["success"] = "Запись отредактирована";
                return RedirectToAction("Index");
        }


        //GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var TypeOfAtciveFromDb = await _typeOfActiveRepository.GetById((int)id);
            if (TypeOfAtciveFromDb == null)
            {
                return NotFound();
            }
            return View(TypeOfAtciveFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            await _typeOfActiveRepository.Delete(id);
            await _typeOfActiveRepository.Save();
            TempData["success"] = "Запись удалена";
            return RedirectToAction("Index");
        }
    }
}
