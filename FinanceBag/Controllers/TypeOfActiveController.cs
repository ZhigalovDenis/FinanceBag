
using FinanceBag.Data;
using FinanceBag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            //if (ModelState.IsValid)
            //{
                _db.TypeOfActives.Add(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            //}
            //return View(obj);   
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
            //if (ModelState.IsValid)
            //{
                _db.TypeOfActives.Update(obj);
                await _db.SaveChangesAsync();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            //}
            //return View(obj);
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
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }

    }
}
