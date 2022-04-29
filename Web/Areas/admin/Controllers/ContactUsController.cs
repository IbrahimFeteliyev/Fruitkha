using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsManager _contactUsManager;

        public ContactUsController(IContactUsManager contactUsManager)
        {
            _contactUsManager = contactUsManager;
        }

        // GET: ContactUsController
        public IActionResult Index()
        {
            var contactus = _contactUsManager.GetAll();
            return View(contactus);
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var contactus = _contactUsManager.GetById(id.Value);
            return View(contactus);
        }

        // GET: ContactUsController/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var contactus = _contactUsManager.GetById(id.Value);
            return View(contactus);
        }

        // POST: ContactUsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id,ContactUs contactus)
        {
            try
            {
                _contactUsManager.Delete(contactus);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
