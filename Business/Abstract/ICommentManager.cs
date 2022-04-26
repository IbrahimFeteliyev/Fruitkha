using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentManager
    {
        List<Comment> GetAll();
        Comment GetById(int id);
        void Create(Comment comment);
        void Edit(Comment comment);
        void Delete(Comment comment);
    }
}
