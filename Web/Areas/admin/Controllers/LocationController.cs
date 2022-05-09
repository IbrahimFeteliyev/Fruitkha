using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class LocationController : Controller
    {
        private readonly ILocationManager _locationManager;

        public LocationController(ILocationManager locationManager)
        {
            _locationManager = locationManager;
        }

        // GET: LocationController
        public ActionResult Index()
        {
            var location = _locationManager.GetAll();
            return View(location);
        }

        // GET: LocationController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var location = _locationManager.GetById(id.Value);
            return View(location);
        }

        // GET: LocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Location location)
        {
            try
            {
                _locationManager.Create(location);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocationController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var location = _locationManager.GetById(id.Value);
            return View(location);
        }

        // POST: LocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Location location)
        {
            try
            {
                _locationManager.Edit(location);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LocationController/Delete/5
        public ActionResult Delete(int id)
        {
            var location = _locationManager.GetById(id);
            return View(location);
        }

        // POST: LocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Location location)
        {
            try
            {
                _locationManager.Delete(location);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
