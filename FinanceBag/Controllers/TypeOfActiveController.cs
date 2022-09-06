
using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace FinanceBag.Controllers
{
    public class TypeOfActiveController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TypeOfActiveController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TypeOfActive> objTypeOfActiv = await _db.TypeOfActives.ToListAsync(); 
            return   View(objTypeOfActiv);
        }
        //GET
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
            IEnumerable<TypeOfActive> objTypeOfActiv = await _db.TypeOfActives.ToListAsync();
            foreach (var item in objTypeOfActiv)
            {
                if (item.Type == obj.Type.Trim(' ', '\t'))
                {
                    IsAvilible = 1;
                    break;
                }             
            }  
            if(IsAvilible == 0)
            {
                _db.TypeOfActives.Add(obj);
                await _db.SaveChangesAsync();
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
            var TypeOfAtciveFromDb = await _db.TypeOfActives.FindAsync(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (TypeOfAtciveFromDb == null)
            {
                return NotFound();
            }

            return View(TypeOfAtciveFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TypeOfActive obj)
        {
            byte IsAvilible = 0;
            IEnumerable<TypeOfActive> objTypeOfActiv = await _db.TypeOfActives.ToListAsync();
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
                _db.TypeOfActives.Update(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Запись отредактирована";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("Type", $"Запись {obj.Type} уже существет");
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
            var TypeOfAtciveFromDb = await _db.TypeOfActives.FindAsync(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (TypeOfAtciveFromDb == null)
            {
                return NotFound();
            }

            return View(TypeOfAtciveFromDb);
        }



        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int? id)
        {
            var obj = await _db.TypeOfActives.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.TypeOfActives.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Запись удалена";
            return RedirectToAction("Index");
        }

    }
}
