using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOurNewManager
    {
        List<OurNew> GetAll();
        OurNew GetById(int id);
        void Create(OurNew ournew);
        void Edit(OurNew ournew);
        void Delete(OurNew ournew);
    }
}
