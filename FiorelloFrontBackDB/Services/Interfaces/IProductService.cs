using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.ViewModels.Products;

namespace FiorelloFrontBackDB.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllWithImagesAsync();
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        List<ProductVM> GetMappedDatas(List<Product> products);
        Task<List<Product>> GetAllPaginatedAsync(int page,int take = 4);
        Task<int> GetCountAsync();
        
    }
}
