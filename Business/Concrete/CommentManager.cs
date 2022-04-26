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
    public class CommentManager : ICommentManager
    {
        private readonly FruitkhaDbContext _context;

        public CommentManager(FruitkhaDbContext context)
        {
            _context = context;
        }


        public void Create(Comment comment)
        {
            comment.PublishDate = DateTime.Now;
            _context.Comments.Add(comment);
            _context.SaveChanges();

        }


        public void Delete(Comment comment)
        {
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }



        public void Edit(Comment comment)
        {
            comment.UpdateDate = DateTime.Now;
            _context.Comments.Update(comment);
            _context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            var comment = _context.Comments.ToList();
            return (comment);
        }

        public Comment GetById(int id)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.ID == id);
            return (comment);

        }
    }
}
