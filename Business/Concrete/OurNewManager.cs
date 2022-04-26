using Business.Abstract;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OurNewManager : IOurNewManager
    {
        private readonly FruitkhaDbContext _context;

        public OurNewManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(OurNew ournew)
        {
            ournew.PublishDate = DateTime.Now;
            _context.OurNews.Add(ournew);
            _context.SaveChanges();
        }

        public void Delete(OurNew ournew)
        {
           _context.OurNews.Remove(ournew);
            _context.SaveChanges();
        }

        public void Edit(OurNew ournew)
        {
            ournew.UpdateDate = DateTime.Now;
            _context.OurNews.Update(ournew);
            _context.SaveChanges();
        }

        public List<OurNew> GetAll()
        {
            var ournew = _context.OurNews.ToList();
            return ournew; 
        }

        public OurNew GetById(int id)
        {
            var ournew = _context.OurNews.FirstOrDefault(x => x.ID == id);
            return ournew; 
        }
    }
}
