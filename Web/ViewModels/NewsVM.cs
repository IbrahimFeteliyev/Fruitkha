using Core.Helper;
using Entities;

namespace Web.ViewModels
{
    public class NewsVM
    {
        public Pager Pager { get; set; }
        public Article Article { get; set; }
        public List<Article> Articles { get; set; }
        public MyUser MyUser { get; set; }
    }
}
