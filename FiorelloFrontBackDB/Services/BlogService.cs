using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services.Interfaces;
using FiorelloFrontBackDB.ViewModels.Blogs;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FiorelloFrontBackDB.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> BlogCountAsync()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task CreateAsync(BlogCreateVM blogCreateVM)
        {
            await _context.Blogs.AddAsync(new Blog { Title = blogCreateVM.Title, Description = blogCreateVM.Description, Image = blogCreateVM.Image });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var blog = await GetByIdAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Blog blog, BlogEditVM blogEdit)
        {
            blog.Title = blogEdit.BlogTitle;
            blog.Description = blogEdit.BlogDescription;
            blog.Image = blogEdit.Image;

            await _context.SaveChangesAsync();
        }

        public Task<bool> ExistAsync(string name)
        {
            return _context.Blogs.AnyAsync(m=>m.Title == name);
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _context.Blogs.Where(m => !m.SoftDeleted).ToListAsync();
        }

        public async Task<List<BlogVM>> GetAllOrderByAsync()
        {
            var blogs = await GetAllAsync();
            return blogs.Select(m => new BlogVM { Id = m.Id, Title = m.Title }).ToList().OrderByDescending(m => m.Id).ToList();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs.Where(m => !m.SoftDeleted).FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Blog>> SkipTakeAsync(int skipCount)
        {
            return await _context.Blogs.Skip(skipCount).Take(3).ToListAsync();
        }

        public async Task<List<Blog>> TakeAsync()
        {
            return await _context.Blogs.Where(m => !m.SoftDeleted).Take(3).ToListAsync();
        }
    }
}
