using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services.Interfaces;
using FiorelloFrontBackDB.ViewModels.Products;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFrontBackDB.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.ProductImages).Include(m=>m.Category).ToListAsync();
        }

        public async Task<List<Product>> GetAllPaginatedAsync(int page, int take = 4)
        {
            return await _context.Products.Where(m => !m.SoftDeleted)
                                          .Include(m => m.ProductImages)
                                          .Include(m=>m.Category)
                                          .Skip((page - 1) * take)
                                          .Take(take)
                                          .ToListAsync();

        }

        public async Task<List<Product>> GetAllWithImagesAsync()
        {
            return await _context.Products.Where(m => !m.SoftDeleted).Include(m => m.ProductImages).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Where(m => !m.SoftDeleted)
                                                     .Include(m => m.ProductImages)
                                                     .Include(m => m.Category)
                                                     .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Products.CountAsync();
        }

        public List<ProductVM> GetMappedDatas(List<Product> products)
        {
            return products.Select(m => new ProductVM
            {
                Id = m.Id,
                Name = m.Name,
                Image = m.ProductImages.FirstOrDefault(m => m.IsMain).ImageUrl,
                Description = m.Description,
                Price = m.Price,
                Category = m.Category.Name,
            }).ToList();
        }
    }
}
