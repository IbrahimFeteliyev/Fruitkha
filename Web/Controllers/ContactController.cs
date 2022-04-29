using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactUsManager _contactUsManager;

        public ContactController(ILogger<ContactController> logger, IContactUsManager contactUsManager)
        {
            _logger = logger;
            _contactUsManager = contactUsManager;
        }

        public IActionResult Index()
        {
            ContactVM vm = new()
            {
                
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Contact(ContactUs contactus)
        {
            if (contactus.Name != null & contactus.Email != null & contactus.Phone != null & contactus.Subject != null & contactus.Message != null )
            {

                _contactUsManager.PostMessage(contactus);

            }

            return RedirectToAction(nameof(Contact));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
