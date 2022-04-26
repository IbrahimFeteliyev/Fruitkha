using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class DealController : Controller
    {
        private readonly IDealManager _dealManager;
        private readonly IWebHostEnvironment _environment;
        public DealController(IDealManager dealManager, IWebHostEnvironment environment)
        {
            _dealManager = dealManager;
            _environment = environment;
        }

        // GET: DealController
        public IActionResult Index()
        {
            var deal = _dealManager.GetAll();
            return View(deal);
        }

        // GET: DealController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var deal = _dealManager.GetById(id.Value);
            return View(deal);
        }

        // GET: DealController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DealController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Deal deal, IFormFile Image)
        {

            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {
                deal.PhotoURL = path;
                _dealManager.Create(deal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DealController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var deal = _dealManager.GetById(id.Value);
            return View(deal);
        }

        // POST: DealController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Deal deal, IFormFile Images)
        {
            if (Images != null)
            {
                string path = "/files/" + Guid.NewGuid() + Images.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Images.CopyToAsync(fileStream);
                }
                deal.PhotoURL = path;
            }

            try
            {
                _dealManager.Edit(deal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DealController/Delete/5
        public IActionResult Delete(int? id)
        {
            var deal = _dealManager.GetById(id.Value);
            return View(deal);
        }

        // POST: DealController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Deal deal)
        {
            try
            {
                _dealManager.Delete(deal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
