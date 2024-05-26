using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services;
using FiorelloFrontBackDB.Services.Interfaces;
using FiorelloFrontBackDB.ViewModels.Blogs;
using FiorelloFrontBackDB.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace FiorelloFrontBackDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly AppDbContext _context;
        public BlogController(IBlogService blogService,
                              AppDbContext context)
        {
            _blogService = blogService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllOrderByAsync();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateVM blog)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool existblog = await _blogService.ExistAsync(blog.Title);

            if (existblog)
            {
                ModelState.AddModelError("Title", "This blog has already exist");
                return View();
            }

            await _blogService.CreateAsync(blog);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            var blog = await _blogService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();
            return View(new BlogDetailVM { Title = blog.Title, Description = blog.Description, CreateDate = blog.Date, Image = blog.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            await _blogService.DeleteAsync((int) id);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet] 
        public async Task<IActionResult> Edit(int? id)
        {
            if(id is null)
            {
                return BadRequest();
            }
            var blog = await _blogService.GetByIdAsync((int)id);

            if(blog is null)
            {
                return NotFound();
            }

            return View(new BlogEditVM { Id = blog.Id, BlogTitle = blog.Title, BlogDescription = blog.Description, Image = blog.Image });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,BlogEditVM blogEdit)
        {

            if (!ModelState.IsValid) return View();

            if (id is null) return BadRequest();

            var blog = await _blogService.GetByIdAsync((int)id);

            if (blog is null) return NotFound();


            await _blogService.EditAsync(blog, blogEdit);

            return RedirectToAction(nameof(Index));

        }


    }
}
