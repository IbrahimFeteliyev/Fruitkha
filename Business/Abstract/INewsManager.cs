using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface INewsManager 
    {
        List<News> GetAll();
        void Create(News News);
        News GetById(int? id);
        void Update(News News);

        void Delete(News News);

        List<News> LastNews(string userId, int newsId);

        int GetAllCount();

        List<News> GetAll(int? pageNo, int recordSize);
    }
}
