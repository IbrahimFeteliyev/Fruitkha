using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class SingleNewsController : Controller
    {
        private readonly ILogger<SingleNewsController> _logger;

        public SingleNewsController(ILogger<SingleNewsController> logger)
        {
            _logger = logger;
        }

        // GET: SingleNewsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SingleNewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SingleNewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SingleNewsController/Create
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

        // GET: SingleNewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SingleNewsController/Edit/5
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

        // GET: SingleNewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SingleNewsController/Delete/5
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
