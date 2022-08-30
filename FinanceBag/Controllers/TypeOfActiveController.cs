
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

        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
