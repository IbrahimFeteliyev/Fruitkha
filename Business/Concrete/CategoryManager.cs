using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess;
using Entities;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryManager
    {
        private readonly FruitkhaDbContext _context;

        public CategoryManager(FruitkhaDbContext context)
        {
            _context = context;
        }

      
        public void Create(Category category)
        {
            category.PublishDate = DateTime.Now;
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

        }

        public void Edit(Category category)
        {
            category.UpdateDate = DateTime.Now;
            _context.Categories.Update(category);
            _context.SaveChanges();
        }


        public List<Category> GetAll()
        {
            var category = _context.Categories.ToList();
            return category;
        }

        public Category GetById(int? id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.ID == id);
                return category;
        }


    }
}
