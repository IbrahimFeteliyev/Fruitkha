using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class CompanyController : Controller
    {
        private readonly ICompanyManager _companyManager;
        private readonly IWebHostEnvironment _environment;

        public CompanyController(ICompanyManager companyManager, IWebHostEnvironment environment)
        {
            _companyManager = companyManager;
            _environment = environment;
        }


        // GET: CompanyController
        public IActionResult Index()
        {
            var company = _companyManager.GetAll();
            return View(company);
        }

        // GET: CompanyController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var company = _companyManager.GetById(id.Value);
            return View(company);
        }

        // GET: CompanyController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {

                company.Logo = path;
                _companyManager.Create(company);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var company = _companyManager.GetById(id.Value);
            return View(company);
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Company company, IFormFile Images)
        {
            if (Images != null)
            {
                string path = "/files/" + Guid.NewGuid() + Images.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Images.CopyToAsync(fileStream);
                }
                company.Logo = path;
            }

            try
            {
                _companyManager.Edit(company);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyController/Delete/5
        public IActionResult Delete(int id)
        {
            var company = _companyManager.GetById(id);
            return View(company);
        }

        // POST: CompanyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Company company)
        {
            try
            {
                _companyManager.Delete(company);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
