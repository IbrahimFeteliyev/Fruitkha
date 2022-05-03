using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class New : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public string PhotoURL { get; set; }
    }
}
