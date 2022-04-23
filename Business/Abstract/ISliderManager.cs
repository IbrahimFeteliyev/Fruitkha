using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISliderManager
    {
        List<Slider> GetAll();
        Slider GetById(int id);
        void Create(Slider slider);
        void Edit(Slider slider);
        void Delete(Slider slider);
        
    }
}
