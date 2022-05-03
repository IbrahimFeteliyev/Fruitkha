using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISliderManager _sliderManager;
        private readonly IServiceManager _serviceManager;
        private readonly IProductManager _productManager;
        private readonly IDealManager _dealManager;
        private readonly ICommentManager _commentManager;
        private readonly ICompanyManager _companyManager;
        public HomeController(ILogger<HomeController> logger, ISliderManager sliderManager, IServiceManager serviceManager, IProductManager productManager, IDealManager dealManager, ICommentManager commentManager, ICompanyManager companyManager)
        {
            _logger = logger;
            _sliderManager = sliderManager;
            _serviceManager = serviceManager;
            _productManager = productManager;
            _dealManager = dealManager;
            _commentManager = commentManager;
            _companyManager = companyManager;
        }

        public IActionResult Index()
        {
            HomeVM vm = new()
            {
                Sliders = _sliderManager.GetAll(),
                Services = _serviceManager.GetAll(),
                Products = _productManager.GetAll(),
                Deals = _dealManager.GetAll(),
                Comments = _commentManager.GetAll(),
                Companies = _companyManager.GetAll(),
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