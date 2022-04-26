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
    public class DealManager : IDealManager
    {
        private readonly FruitkhaDbContext _context;

        public DealManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Deal deal)
        {
            deal.PublishDate = DateTime.Now;
            _context.Deals.Add(deal);
            _context.SaveChanges();
        }

        public void Delete(Deal deal)
        {
            _context.Deals.Remove(deal);
            _context.SaveChanges();
        }

        public void Edit(Deal deal)
        {
            deal.UpdateDate = DateTime.Now;
            _context.Deals.Update(deal);
            _context.SaveChanges();
        }

        public List<Deal> GetAll()
        {
            var deal = _context.Deals.ToList();
            return deal;
        }

        public Deal GetById(int id)
        {
            var deal = _context.Deals.FirstOrDefault(x => x.ID == id);
            return deal;
        }
    }
}
