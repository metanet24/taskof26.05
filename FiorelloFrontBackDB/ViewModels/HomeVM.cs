using FiorelloFrontBackDB.Models;

namespace FiorelloFrontBackDB.ViewModels
{
    public class HomeVM
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public About AboutParts { get; set; }
        public List<Expert> Experts { get; set; }   
        public List<Position> Positions { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<InstaSlider> InstaSliders { get; set; }
    }
}
