using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICompanyManager
    {
        List<Company> GetAll();
        Company GetById(int id);
        void Create(Company company);
        void Edit(Company company);
        void Delete(Company company);
    }
}
