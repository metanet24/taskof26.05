using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.ViewModels.Categories;

namespace FiorelloFrontBackDB.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<List<CategoryVM>> GetAllOrderByDescendingAsync();
        Task<bool> ExistAsync(string name);
        Task CreateAsync(CategoryCreateVM category);
        Task<Category> GetWithProductsAsync(int id);
        Task DeleteAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task EditAsync(Category category,CategoryEditVM categoryEdit);
    }
}
