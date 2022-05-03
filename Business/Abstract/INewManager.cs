using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INewManager
    {
        List<New> GetAll();
        New GetById(int id);
        void Create(New neww);
        void Edit(New neww);
        void Delete(New neww);
        New GetNewById(int? neww);
        List<New> GetAll(int? pageNo, int recordSize);
        int GetAllCount();
        List<New> GetNewAll();
    }
}
