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
    public class ServiceManager : IServiceManager
    {
        private readonly FruitkhaDbContext _context;

        public ServiceManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Service service)
        {
            service.PublishDate = DateTime.Now;
            _context.Services.Add(service);
            _context.SaveChanges();
        }

        public void Delete(Service service)
        {
            _context.Services.Remove(service);
            _context.SaveChanges();
        }

        public void Edit(Service service)
        {
            service.UpdateDate = DateTime.Now;
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public List<Service> GetAll()
        {
            var service = _context.Services.ToList();
            return service;
        }

        public Service GetById(int id)
        {
            var service = _context.Services.FirstOrDefault(x => x.ID == id);
            return service;
        }
    }
}
