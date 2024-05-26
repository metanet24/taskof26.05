using System.ComponentModel.DataAnnotations;

namespace FiorelloFrontBackDB.ViewModels.Blogs
{
    public class BlogCreateVM
    {
        [Required(ErrorMessage = "Title field can`t be empty")]
        [StringLength(20, ErrorMessage = "String length must less than 20")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description field can`t be empty")]
        [StringLength(50, ErrorMessage = "String length must less than 50")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image is required")]
        public string Image {  get; set; }
    }
}
