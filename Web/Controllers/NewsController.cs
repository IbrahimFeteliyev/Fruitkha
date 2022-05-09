using Business.Abstract;
using Core.Helper;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly ILogger<NewsController> _logger;
        private readonly IArticleManager _articleManager;
        private readonly UserManager<MyUser> _userManager;

        public NewsController(ILogger<NewsController> logger, IArticleManager articleManager, UserManager<MyUser> userManager)
        {
            _logger = logger;
            _articleManager = articleManager;
            _userManager = userManager;
        }
        public IActionResult Index(int? recordSize = 2, int? PageNo = 1)
        {
            NewsVM vm = new()
            {
                Articles = _articleManager.GetAll(PageNo, recordSize.Value)
            };

            vm.Pager = new Pager(_articleManager.GetAllCount(), PageNo, 2, 3);
            return View(vm);
        }

        public IActionResult Details(int? id)
        {
            var article = _articleManager.GetById(id);
            var selectedUser = _userManager.FindByIdAsync(article.MyUserId);

            NewsVM vm = new()
            {
                MyUser = selectedUser.Result,
                Article = _articleManager.GetById(id),
        
            };

            return View(vm);
        }
    }
}
