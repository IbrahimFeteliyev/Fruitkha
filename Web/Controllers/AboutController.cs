using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;
        private readonly IServiceManager _serviceManager;
        private readonly ICommentManager _commentManager;
        private readonly ICompanyManager _companyManager;
        private readonly IOurTeamManager _ourteamManager;

        public AboutController(ILogger<AboutController> logger, IServiceManager serviceManager, ICommentManager commentManager, ICompanyManager companyManager, IOurTeamManager ourteamManager)
        {
            _logger = logger;
            _serviceManager = serviceManager;
            _commentManager = commentManager;
            _companyManager = companyManager;
            _ourteamManager = ourteamManager;
        }



        public IActionResult About()
        {
            AboutVM vm = new()
            {
                Services = _serviceManager.GetAll(),
                Comments = _commentManager.GetAll(),
                Companies = _companyManager.GetAll(),
                OurTeams = _ourteamManager.GetAll(),
            };

            return View(vm);
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
