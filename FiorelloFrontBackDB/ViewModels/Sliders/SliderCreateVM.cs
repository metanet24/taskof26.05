using System.ComponentModel.DataAnnotations;

namespace FiorelloFrontBackDB.ViewModels.Sliders
{
    public class SliderCreateVM
    {
        [Required]
        public List<IFormFile> Images { get; set; }
    }
}
