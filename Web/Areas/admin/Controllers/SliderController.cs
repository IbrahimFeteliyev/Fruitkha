using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class SliderController : Controller
    {
        private readonly ISliderManager _sliderManager;
        private readonly IWebHostEnvironment _environment;

        public SliderController(ISliderManager sliderManager, IWebHostEnvironment environment)
        {
            _sliderManager = sliderManager;
            _environment = environment;
        }

        // GET: SliderController
        public IActionResult Index()
        {
            var slider = _sliderManager.GetAll();
            return View(slider);
        }

        // GET: SliderController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var slider = _sliderManager.GetById(id.Value);
            return View(slider);
        }

        // GET: SliderController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider, IFormFile Image)
        {

            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {
                slider.PhotoURL = path;     
                _sliderManager.Create(slider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var slider = _sliderManager.GetById(id.Value);
            return View(slider);
        }

        // POST: SliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Slider slider,IFormFile Images)
        {
            if (Images != null)
            {
                string path = "/files/" + Guid.NewGuid() + Images.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Images.CopyToAsync(fileStream);
                }
                slider.PhotoURL = path;
            }
            try
            {
               
                _sliderManager.Edit(slider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SliderController/Delete/5
        public IActionResult Delete(int id)
        {
            var slider = _sliderManager.GetById(id);
            return View(slider);
        }

        // POST: SliderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Slider slider)
        {
            try
            {
                _sliderManager.Delete(slider);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}


//saaaaaaaaaaaaaaaaaaaa