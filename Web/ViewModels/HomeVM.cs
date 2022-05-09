using Entities;

namespace Web.ViewModels
{
    public class HomeVM
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        public List<Product> Products { get; set; }
        public List<Deal> Deals { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Company> Companies { get; set; }
        public List<Article> Articles { get; set; }
        public MyUser MyUser { get; set; }

    }
}
