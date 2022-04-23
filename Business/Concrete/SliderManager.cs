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
    public class SliderManager : ISliderManager
    {
        private readonly FruitkhaDbContext _context;

        public SliderManager(FruitkhaDbContext context)
        {
            _context = context;
        }

        public void Create(Slider slider)
        {
            slider.PublishDate = DateTime.Now;
            _context.Sliders.Add(slider);
            _context.SaveChanges();

        }

        public void Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
            _context.SaveChanges();
        }

        public void Edit(Slider slider)
        {
            slider.UpdateDate = DateTime.Now;
            _context.Sliders.Update(slider);
            _context.SaveChanges();
        }

        public List<Slider> GetAll()
        {
            var slider = _context.Sliders.ToList();
            return slider;

        }

        public Slider GetById(int id)
        {
            var slider = _context.Sliders.FirstOrDefault(x => x.ID == id);
            return slider;
        }
    }
}
