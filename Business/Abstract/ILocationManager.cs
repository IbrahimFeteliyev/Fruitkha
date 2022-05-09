using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILocationManager
    {
        List<Location> GetAll();
        Location GetById(int id);
        void Create(Location location);
        void Edit(Location location);
        void Delete(Location location);
    }
}
