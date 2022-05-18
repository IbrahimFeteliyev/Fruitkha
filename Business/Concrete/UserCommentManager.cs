using Business.Abstract;
using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserCommentManager : IUserCommentManager
    {
        private readonly FruitkhaDbContext _context;

        public UserCommentManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void AddComment(UserComment usercomment)
        {
            usercomment.PublishDate = DateTime.Now;
            _context.Add(usercomment);  
            _context.SaveChanges();
        }

        public List<UserComment> GetComment(int Id)
        {
            var Comment = _context.UserComments.Where(x => x.ArticleId == Id).ToList();
            return Comment;
        }
    }
}
