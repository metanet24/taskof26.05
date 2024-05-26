using System.ComponentModel.DataAnnotations;

namespace FiorelloFrontBackDB.ViewModels.Categories
{
    public class CategoryCreateVM
    {
        [Required(ErrorMessage = "*Required")]
        [StringLength(20, ErrorMessage = "String length must less than 20")]
        public string Name { get; set; }
    }
}
