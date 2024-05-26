using FiorelloFrontBackDB.Models;

namespace FiorelloFrontBackDB.Services.Interfaces
{
    public interface ISliderInstaService
    {
        Task<List<InstaSlider>> GetAllAsync();
    }
}
