using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductManager _productManager;
        private readonly ICategoryManager _categoryManager;
        public ProductController(ILogger<ProductController> logger, IProductManager productManager, ICategoryManager categoryManager)
        {
            _logger = logger;
            _productManager = productManager;
            _categoryManager = categoryManager;
        }

        // GET: SingleProductController
        public IActionResult Index()
        {
            ProductVM vm = new()
            {

                Products = _productManager.GetAllProducts(),
                
            };

            return View(vm);
        }

        // GET: SingleProductController/Details/5
        public IActionResult Details(int id)
        {

            SingleProductVM vm = new()
            {
                Product = _productManager.GetById(id),
                Products = _productManager.GetAll(),
                Categories = _categoryManager.GetAll(), 

            };


            return View(vm);
        }

        // GET: SingleProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SingleProductController/Create
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

        // GET: SingleProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SingleProductController/Edit/5
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

        // GET: SingleProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SingleProductController/Delete/5
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
