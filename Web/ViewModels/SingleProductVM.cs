using Entities;

namespace Web.ViewModels
{
    public class SingleProductVM
    {
        public Product Product { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        
        
    }
}
