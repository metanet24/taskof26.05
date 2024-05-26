using FiorelloFrontBackDB.Models;

namespace FiorelloFrontBackDB.Services.Interfaces
{
    public interface IExpertService
    {
        Task<List<Expert>> GetAllAsync();
    }
}
