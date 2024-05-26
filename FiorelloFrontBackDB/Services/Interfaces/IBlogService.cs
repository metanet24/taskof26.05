using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.ViewModels.Blogs;

namespace FiorelloFrontBackDB.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetAllAsync();
        Task<List<BlogVM>> GetAllOrderByAsync();
        Task<List<Blog>> TakeAsync();
        Task<List<Blog>> SkipTakeAsync(int skipCount);
        Task<int> BlogCountAsync();
        Task<Blog> GetByIdAsync(int id);
        Task<bool> ExistAsync(string name);
        Task CreateAsync(BlogCreateVM blogCreateVM);
        Task DeleteAsync(int id);
        Task EditAsync(Blog blog, BlogEditVM blogEdit);
    }
}
