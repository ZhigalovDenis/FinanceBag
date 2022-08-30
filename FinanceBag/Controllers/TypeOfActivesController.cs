using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinanceBag.Data;
using FinanceBag.Models;

namespace FinanceBag.Controllers
{
    public class TypeOfActivesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TypeOfActivesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TypeOfActives
        public async Task<IActionResult> Index()
        {
              return _context.TypeOfActives != null ? 
                          View(await _context.TypeOfActives.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TypeOfActives'  is null.");
        }

        // GET: TypeOfActives/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TypeOfActives == null)
            {
                return NotFound();
            }

            var typeOfActive = await _context.TypeOfActives
                .FirstOrDefaultAsync(m => m.TypeOfActive_id == id);
            if (typeOfActive == null)
            {
                return NotFound();
            }

            return View(typeOfActive);
        }

        // GET: TypeOfActives/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeOfActives/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeOfActive_id,Type")] TypeOfActive typeOfActive)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeOfActive);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfActive);
        }

        // GET: TypeOfActives/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TypeOfActives == null)
            {
                return NotFound();
            }

            var typeOfActive = await _context.TypeOfActives.FindAsync(id);
            if (typeOfActive == null)
            {
                return NotFound();
            }
            return View(typeOfActive);
        }

        // POST: TypeOfActives/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeOfActive_id,Type")] TypeOfActive typeOfActive)
        {
            if (id != typeOfActive.TypeOfActive_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeOfActive);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeOfActiveExists(typeOfActive.TypeOfActive_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(typeOfActive);
        }

        // GET: TypeOfActives/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TypeOfActives == null)
            {
                return NotFound();
            }

            var typeOfActive = await _context.TypeOfActives
                .FirstOrDefaultAsync(m => m.TypeOfActive_id == id);
            if (typeOfActive == null)
            {
                return NotFound();
            }

            return View(typeOfActive);
        }

        // POST: TypeOfActives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TypeOfActives == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TypeOfActives'  is null.");
            }
            var typeOfActive = await _context.TypeOfActives.FindAsync(id);
            if (typeOfActive != null)
            {
                _context.TypeOfActives.Remove(typeOfActive);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeOfActiveExists(int id)
        {
          return (_context.TypeOfActives?.Any(e => e.TypeOfActive_id == id)).GetValueOrDefault();
        }
    }
}
