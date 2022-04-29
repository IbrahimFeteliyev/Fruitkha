using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class OurTeamController : Controller
    {
        private readonly IOurTeamManager _ourTeamManager;
        private readonly IWebHostEnvironment _environment;

        public OurTeamController(IWebHostEnvironment environment, IOurTeamManager ourTeamManager)
        {
            _environment = environment;
            _ourTeamManager = ourTeamManager;
        }

        // GET: OurTeamController
        public IActionResult Index()
        {
            var ourteam = _ourTeamManager.GetAll();
            return View(ourteam);
        }

        // GET: OurTeamController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var ourteam = _ourTeamManager.GetById(id.Value);
            return View(ourteam);

        }

        // GET: OurTeamController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OurTeamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OurTeam ourteam, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {
                ourteam.PhotoURL = path;
                _ourTeamManager.Create(ourteam);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OurTeamController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var ourteam = _ourTeamManager.GetById(id.Value);
            return View(ourteam);
        }

        // POST: OurTeamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OurTeam ourteam, IFormFile Images)
        {
            if (Images != null)
            {
                string path = "/files/" + Guid.NewGuid() + Images.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Images.CopyToAsync(fileStream);
                }
                ourteam.PhotoURL = path;
            }
            try
            {

                _ourTeamManager.Edit(ourteam);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OurTeamController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var ourteam = _ourTeamManager.GetById(id.Value);
            return View(ourteam);
        }

        // POST: OurTeamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, OurTeam ourteam)
        {
            try
            {
                _ourTeamManager.Delete(ourteam);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
