using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product : Base
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string PhotoURL { get; set; }
    }
}
