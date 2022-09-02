using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceBag.Controllers
{
    public class ActiveController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ActiveController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Active> objActiv = await _db.Actives.ToListAsync();
            return View(objActiv);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Active obj)
        {
            byte IsAvilible = 0;
            IEnumerable<Active> objTypeOfActiv = await _db.Actives.ToListAsync();
            foreach (var item in objTypeOfActiv)
            {
                if (item.ISIN_id == obj.ISIN_id.Trim(' ', '\t'))
                {
                    IsAvilible = 1;
                    break;
                }
            }
            if (IsAvilible == 0)
            {
                _db.Actives.Add(obj);
                await _db.SaveChangesAsync();
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
            if (id == null /*|| id == 0*/)
            {
                return NotFound();
            }
            var AtciveFromDb = await _db.Actives.FindAsync(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

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
            //if (ModelState.IsValid)
            //{
            _db.Actives.Update(obj);
            await _db.SaveChangesAsync();
            TempData["success"] = "Запись отредактирована";
            return RedirectToAction("Index");
            //}
            //return View(obj);
        }

        //GET
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null /*|| id == 0*/)
            {
                return NotFound();
            }
            var AtciveFromDb = await _db.Actives.FindAsync(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

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
            var obj = await _db.Actives.FindAsync(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Actives.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Запись удалена";
            return RedirectToAction("Index");
        }
    }
}
