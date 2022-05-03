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
    public class NewsManager : INewsManager
    {
        private readonly FruitkhaDbContext _context;

        public NewsManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(News News)
        {
            News.PublishDate = DateTime.Now;    
            _context.News.Add(News);
            _context.SaveChanges();
        }

        public void Delete(News News)
        {
            _context.News.Remove(News);
            _context.SaveChanges();
        }

      

        public News GetById(int? id)
        {
            var News = _context.News
                .Include(x => x.MyUser)
                .FirstOrDefault(x => x.ID == id);

            News.Views += 1;
            Update(News);

            return News;
        }

        public void Update(News News)
        {
            _context.News.Update(News);
            _context.SaveChanges();
        }

        public List<News> GetAll()
        {
            var News = _context.News.Take(3).Include(x => x.MyUser).ToList();
        
            return News;

        }

        public List<News> LastNews(string userId, int newsId)
        {
            var News = _context.News
                .OrderBy(x => x.PublishDate).Take(1)
               
                .Include(x => x.MyUser)
                .Where(x => x.MyUserId== userId && x.ID != newsId)
                .ToList();
                

            return News;

        }

        public List<News> GetAll(int? pageNo, int recordSize)
        {
            if (pageNo == null)
            {
                pageNo = 1;
            }
            int currentPage = 3 * pageNo.Value - 3;


            var blogs = _context.News
                .Skip(currentPage)
                .Take(3)
                .Include(x => x.MyUser)
                .ToList();

            return blogs;
        }

        public int GetAllCount()
        {
            var blogs = _context.News.ToList();
            return blogs.Count();
        }

    }
}
