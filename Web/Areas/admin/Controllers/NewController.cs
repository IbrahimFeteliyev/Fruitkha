using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class NewController : Controller
    {
        private readonly INewManager _newManager;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<User> _userManager;
        public NewController(IWebHostEnvironment environment, UserManager<User> userManager, INewManager newManager)
        {
            _environment = environment;
            _userManager = userManager;
            _newManager = newManager;
        }


        // GET: OurNewController
        public IActionResult Index()
        {
            var ournew = _newManager.GetAll();
            return View(ournew);
        }

        // GET: OurNewController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var ournew = _newManager.GetById(id.Value);
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
        public async Task<IActionResult> Create(New ournew, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {
                var userID = _userManager.GetUserId(HttpContext.User);
                ournew.UserID = userID;
                ournew.PhotoURL = path;
                _newManager.Create(ournew);
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
            var ournew = _newManager.GetById(id.Value);
            return View(ournew);
        }

        // POST: OurNewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(New ournew, IFormFile Images)
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
                _newManager.Edit(ournew);
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
            var ournew = _newManager.GetById(id.Value);
            return View(ournew);
        }

        // POST: OurNewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, New ournew)
        {
            try
            {
                _newManager.Delete(ournew);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
