using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class OurNewController : Controller
    {
        private readonly IOurNewManager _ournewManager;
        private readonly IWebHostEnvironment _environment;
        public OurNewController(IOurNewManager ournewManager, IWebHostEnvironment environment)
        {
            _ournewManager = ournewManager;
            _environment = environment;
        }


        // GET: OurNewController
        public IActionResult Index()
        {
            var ournew = _ournewManager.GetAll();
            return View(ournew);
        }

        // GET: OurNewController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var ournew = _ournewManager.GetById(id.Value);
            return View(ournew);
        }

        // GET: OurNewController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OurNewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OurNew ournew, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {
                ournew.PhotoURL = path;
                _ournewManager.Create(ournew);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OurNewController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var ournew = _ournewManager.GetById(id.Value);
            return View(ournew);
        }

        // POST: OurNewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OurNew ournew, IFormFile Images)
        {
            if (Images != null)
            {
                string path = "/files/" + Guid.NewGuid() + Images.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Images.CopyToAsync(fileStream);
                }
                ournew.PhotoURL = path;
            }

            try
            {
                _ournewManager.Edit(ournew);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OurNewController/Delete/5
        public IActionResult Delete(int? id)
        {
            var ournew = _ournewManager.GetById(id.Value);
            return View(ournew);
        }

        // POST: OurNewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, OurNew ournew)
        {
            try
            {
                _ournewManager.Delete(ournew);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
