using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class UserComment : Base
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsDelete { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
