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
    public class NewManager : INewManager
    {
        private readonly FruitkhaDbContext _context;

        public NewManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(New neww)
        {
            neww.PublishDate = DateTime.Now;
            _context.News.Add(neww);
            _context.SaveChanges();
        }

        public void Delete(New neww)
        {
            _context.News.Remove(neww);
            _context.SaveChanges();
        }

        public void Edit(New neww)
        {
            _context.News.Update(neww);
            _context.SaveChanges();
        }

        public List<New> GetAll()
        {
            var neww = _context.News.Include(x => x.User).ToList();
            return neww;
        }

        public List<New> GetAll(int? pageNo, int recordSize)
        {
            if (pageNo == null)
            {
                pageNo = 1;
            }
            int currentPage = 6 * pageNo.Value - 6;


            var neww = _context.News.Skip(currentPage).Take(recordSize).Include(x => x.User).ToList();
            return neww;
        }

        public int GetAllCount()
        {
            var neww = _context.News.ToList();
            return neww.Count;
        }

        public New GetById(int id)
        {
            var neww = _context.News.FirstOrDefault(x => x.ID == id);
            return neww;
        }

        public List<New> GetNewAll()
        {
            var neww = _context.News.Take(3).Include(x => x.User).ToList();
            return neww;
        }

        public New GetNewById(int? id)
        {
            var neww = _context.News.Include(x => x.User).FirstOrDefault(x => x.ID == id);
            return neww;
        }
    }
}
