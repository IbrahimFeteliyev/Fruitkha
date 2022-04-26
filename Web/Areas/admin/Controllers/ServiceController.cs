using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: ServiceController
        public IActionResult Index()
        {
            var service = _serviceManager.GetAll();
            return View(service);
        }

        // GET: ServiceController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var service = _serviceManager.GetById(id.Value);
            return View(service);
        }

        // GET: ServiceController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            try
            {
                _serviceManager.Create(service);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var service = _serviceManager.GetById(id.Value);
            return View(service);
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service service)
        {
            try
            {
                _serviceManager.Edit(service);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Delete/5
        public IActionResult Delete(int id)
        {
            var service = _serviceManager.GetById(id);
            return View(service);
        }

        // POST: ServiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Service service)
        {
            try
            {
                _serviceManager.Delete(service);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
