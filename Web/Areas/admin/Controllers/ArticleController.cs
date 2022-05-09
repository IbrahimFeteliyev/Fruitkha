using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleManager _articleManager;
        private readonly IWebHostEnvironment _environment;
        private readonly UserManager<MyUser> _userManager;
        public ArticleController(IArticleManager articleManager, IWebHostEnvironment environment, UserManager<MyUser> userManager)
        {
            _articleManager = articleManager;
            _environment = environment;
            _userManager = userManager;
        }

        // GET: ArticleController
        public IActionResult Index(int? pageNo, int? recordSize = 2)
        {
            var articles = _articleManager.GetAll(pageNo, recordSize.Value);
            return View(articles);
        }

        // GET: ArticleController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var article = _articleManager.GetById(id.Value);
            return View(article);
        }

        // GET: ArticleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Article article, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                article.PhotoURL = path;
                article.MyUserId = userId;
                _articleManager.Create(article);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var article = _articleManager.GetById(id.Value);
            return View(article);
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Article article, IFormFile Images)
        {
            if (Images != null)
            {
                string path = "/files/" + Guid.NewGuid() + Images.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Images.CopyToAsync(fileStream);
                }
                article.PhotoURL = path;
            }

            try
            {
                _articleManager.Edit(article);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Delete/5
        public ActionResult Delete(int? id)
        {
            var article = _articleManager.GetById(id.Value);
            return View(article);
        }

        // POST: ArticleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Article article)
        {
            try
            {
                _articleManager.Delete(article);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
