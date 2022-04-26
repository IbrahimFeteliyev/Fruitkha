using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceManager
    {
        List<Service> GetAll();
        Service GetById(int id);
        void Create(Service service);
        void Edit(Service service);
        void Delete(Service service);

    }
}
