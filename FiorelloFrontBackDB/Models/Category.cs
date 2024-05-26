using System.ComponentModel.DataAnnotations;

namespace FiorelloFrontBackDB.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
