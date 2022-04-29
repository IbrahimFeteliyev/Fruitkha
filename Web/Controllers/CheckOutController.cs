using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    
    public class CheckOutController : Controller
    {
        private readonly ILogger<CheckOutController> _logger;

        public CheckOutController(ILogger<CheckOutController> logger)
        {
            _logger = logger;
        }

        // GET: ChechOutController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ChechOutController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChechOutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChechOutController/Create
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

        // GET: ChechOutController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChechOutController/Edit/5
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

        // GET: ChechOutController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChechOutController/Delete/5
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
