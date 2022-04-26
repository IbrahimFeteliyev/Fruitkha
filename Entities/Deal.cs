using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Deal : Base
    {
        public string ProductName { get; set; }
        public string Description { get; set; } 
        public string CountDown { get; set; }
        public string PhotoURL { get; set; }
        public int Discount { get; set; }
    }
}
