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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IArticleManager _articleManager;
        private readonly UserManager<MyUser> _userManager;
        private readonly IUserCommentManager _usercommentManager;

        public NewsController(ILogger<NewsController> logger, IArticleManager articleManager, UserManager<MyUser> userManager, IUserCommentManager usercommentManager, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _articleManager = articleManager;
            _userManager = userManager;
            _usercommentManager = usercommentManager;
            _httpContextAccessor = httpContextAccessor;
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
            var usercomments = _usercommentManager.GetComment(article.ID);
            var selectedUser = _userManager.FindByIdAsync(article.MyUserId);
            ViewBag.UserComments = usercomments.Count;
            NewsVM vm = new()
            {
                MyUser = selectedUser.Result,
                Article = _articleManager.GetById(id),
                UserComments = usercomments,

            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult AddComment(UserComment usercomment, int Id)
        {
            usercomment.ArticleId = Id;
            _usercommentManager.AddComment(usercomment);
            return RedirectToAction("Index", "Article", new { id = Id });
        }
    }
}
