using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleManager
    {
        List<Article> GetAll(int? pageNo, int recordSize);
        List<Article> GetAll();
        List<Article> GetHomeArticles();
        int GetAllCount();      
        Article GetById(int? id);
        void Create(Article article);
        void Edit(Article article);
        void Delete(Article article);
    }
}
