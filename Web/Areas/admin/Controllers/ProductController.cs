using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IProductManager _productManager;
        private readonly IWebHostEnvironment _environment;
        public ProductController(IProductManager productManager, IWebHostEnvironment environment)
        {
            _productManager = productManager;
            _environment = environment;
        }


        // GET: ProductController
        public IActionResult Index()
        {
            var product = _productManager.GetAllProducts();
            return View(product);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var product = _productManager.GetById(id.Value);
            return View(product);
        }

        // GET: ProductController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product,IFormFile Image)
        {

            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {
                product.PhotoURL = path;
                _productManager.Create(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var product = _productManager.GetById(id.Value);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product, IFormFile Images)
        {
            if(Images != null)
            {
                string path = "/files/" + Guid.NewGuid() + Images.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Images.CopyToAsync(fileStream);
                }
                product.PhotoURL = path;
            }
            

            try
            {
                
                _productManager.Edit(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public IActionResult Delete(int? id)
        {
            var product = _productManager.GetById(id.Value);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Product product)
        {
            try
            {
                _productManager.Delete(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
