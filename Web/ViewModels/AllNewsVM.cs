using Core.Helper;
using Entities;

namespace WebUI.ViewModels
{
    public class AllNewsVM
    {
        public List<News> News { get; set; }
        public Pager Pager { get; set; }
    }
}
