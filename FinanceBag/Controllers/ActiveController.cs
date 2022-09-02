using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBag.Controllers
{
    public class ActiveController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ActiveController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Active> objActiv =  _db.Actives.ToList();
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

            _db.Actives.Add(obj);
            await _db.SaveChangesAsync();
            TempData["success"] = "Новая запись создана успешно";
            return RedirectToAction("Index");

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
