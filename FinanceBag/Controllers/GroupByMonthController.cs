using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceBag.Controllers
{
    public class GroupByMonthController : Controller
    {
        // GET: GroupByMonthController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GroupByMonthController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GroupByMonthController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GroupByMonthController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupByMonthController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GroupByMonthController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GroupByMonthController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GroupByMonthController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
