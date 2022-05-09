using Business.Abstract;
using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleManager
    {
        private readonly FruitkhaDbContext _context;

        public ArticleManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Article article)
        {
            article.PublishDate = DateTime.Now;
            _context.Articles.Add(article);
            _context.SaveChanges();
        }

        public void Delete(Article article)
        {
            _context.Articles.Remove(article);
            _context.SaveChanges();
        }

        public void Edit(Article article)
        {
            article.UpdateDate = DateTime.Now;
            _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public List<Article> GetAll(int? pageNo, int recordSize)
        {
            if (pageNo == null)
            {
                pageNo = 1;
            }
            int currentPage = 2 * pageNo.Value - 2;
            var articles = _context.Articles.Include(x => x.MyUser).Skip(currentPage).Take(2).ToList();
            return articles;
        }

        public List<Article> GetAll()
        {
            var articles = _context.Articles.ToList();
            return articles;
        }

        public int GetAllCount()
        {
            var articles = _context.Articles.ToList();
            return articles.Count();
        }

        public Article GetById(int? id)
        {
            var article = _context.Articles.Include(x => x.MyUser).FirstOrDefault(x => x.ID == id);


            return article;
        }

        public List<Article> GetHomeArticles()
        {
            var article = _context.Articles.Include(x=>x.MyUser).Take(3).ToList();
            return article;
        }
    }
}
