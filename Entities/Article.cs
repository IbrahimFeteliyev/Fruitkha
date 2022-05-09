using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Article : Base
    {
        public string MyUserId { get; set; }
        public MyUser MyUser { get; set; }
        public string PhotoURL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
