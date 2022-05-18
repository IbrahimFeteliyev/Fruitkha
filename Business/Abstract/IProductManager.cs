using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductManager
    {
        List<Product> GetAll();
        List<Product> GetAllProducts();
        Product GetById(int id);
        void Create(Product product);
        void Edit(Product product);
        void Delete(Product product);
        List<Product> GetAll(int? pageNo, int recordSize);
        int GetAllCount();
    }
}
