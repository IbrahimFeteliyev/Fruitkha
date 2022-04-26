using Business.Abstract;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class CommentController : Controller
    {
        private readonly ICommentManager _commentManager;
        private readonly IWebHostEnvironment _environment;
        public CommentController(ICommentManager commentManager, IWebHostEnvironment environment)
        {
            _commentManager = commentManager;
            _environment = environment;
        }


        // GET: CommentController
        public IActionResult Index()
        {
            var comment = _commentManager.GetAll();
            return View(comment);
        }

        // GET: CommentController/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();
            var comment = _commentManager.GetById(id.Value);
            return View(comment);
        }

        // GET: CommentController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CommentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comment comment, IFormFile Image)
        {
            string path = "/files/" + Guid.NewGuid() + Image.FileName;
            using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
            {
                await Image.CopyToAsync(fileStream);
            }

            try
            {
                comment.PhotoURL = path;
                _commentManager.Create(comment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var comment = _commentManager.GetById(id.Value);
            return View(comment);
        }

        // POST: CommentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Comment comment, IFormFile Images)
        {
            if (Images != null)
            {
                string path = "/files/" + Guid.NewGuid() + Images.FileName;
                using (var fileStream = new FileStream(_environment.WebRootPath + path, FileMode.Create))
                {
                    await Images.CopyToAsync(fileStream);
                }
                comment.PhotoURL = path;
            }

            try
            {
                _commentManager.Edit(comment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CommentController/Delete/5
        public IActionResult Delete(int? id)
        {
            var comment = _commentManager.GetById(id.Value);
            return View(comment);
        }

        // POST: CommentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Comment comment)
        {
            try
            {
                _commentManager.Delete(comment);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
