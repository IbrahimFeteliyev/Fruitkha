using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment : Base
    {
        public string Name { get; set; }
        public string Profession { get; set; }
        public string PhotoURL { get; set; }
        public string Description { get; set; }
    }
}
