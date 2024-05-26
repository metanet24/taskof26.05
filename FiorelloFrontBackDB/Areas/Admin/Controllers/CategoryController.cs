using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services.Interfaces;
using FiorelloFrontBackDB.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFrontBackDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;


        public CategoryController(AppDbContext context,ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            //List<CategoryVM> vMs = new();

            //foreach (var item in categories)
            //{

            //    vMs.Add(new CategoryVM{
            //        Id = item.Id,
            //        Name = item.Name,
            //    });
            //}

            return View(await _categoryService.GetAllOrderByDescendingAsync());

        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _categoryService.GetWithProductsAsync((int)id);

            if (category is null) return NotFound();

            CategoryDetailVM model = new()
            {
                Name = category.Name,
                ProductCount = category.Products.Count
            };

            return View(model);
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            bool existCategory = await _categoryService.ExistAsync(category.Name);

            if (existCategory)
            {
                ModelState.AddModelError("Name", "This category has already exist");
                return View();
            }

            await _categoryService.CreateAsync(category);
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _categoryService.GetWithProductsAsync((int)id);

            if (category is null) return NotFound();

            await _categoryService.DeleteAsync(category);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Category category = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            return View(new CategoryEditVM { Id = category.Id, Name = category.Name});  
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,CategoryEditVM category)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id is null) return BadRequest();

            Category existCategory = await _categoryService.GetByIdAsync((int)id);

            if (category is null) return NotFound();

            await _categoryService.EditAsync(existCategory, category);
            
            return RedirectToAction(nameof(Index));
        }

    }
}
