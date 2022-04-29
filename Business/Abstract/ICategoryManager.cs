using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryManager
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Create(Category category);
        void Delete(Category category);
        void Edit(Category category);
    }
}
