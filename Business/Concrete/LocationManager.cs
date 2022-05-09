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
    public class LocationManager : ILocationManager
    {
        private readonly FruitkhaDbContext _context;

        public LocationManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Location location)
        {
            location.PublishDate = DateTime.Now;
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void Delete(Location location)
        {
            _context.Locations.Remove(location);
            _context.SaveChanges();
        }

        public void Edit(Location location)
        {
            location.UpdateDate = DateTime.Now;
            _context.Locations.Update(location);
            _context.SaveChanges();
        }

        public List<Location> GetAll()
        {
            var location = _context.Locations.ToList();
            return location;
        }

        public Location GetById(int id)
        {
            var location = _context.Locations.FirstOrDefault(x => x.ID == id);
            return location;
        }
    }
}
