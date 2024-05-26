    using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services.Interfaces;
using FiorelloFrontBackDB.ViewModels;
using FiorelloFrontBackDB.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FiorelloFrontBackDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IExpertService _expertService;
        private readonly ISliderInstaService _sliderInstaService;
        private readonly IBlogService _blogService;
        private readonly IHttpContextAccessor _accessor;

        public HomeController(AppDbContext context,
                              IProductService productService,
                              ICategoryService categoryService,
                              IExpertService expertService,
                              ISliderInstaService sliderInstaService,
                              IBlogService blogService,IHttpContextAccessor accessor)
        {
            _context = context; 
            _productService = productService;
            _categoryService = categoryService;
            _expertService = expertService;
            _sliderInstaService = sliderInstaService;
            _blogService = blogService;
            _accessor = accessor;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _categoryService.GetAllAsync();
            List<Product> products = await _productService.GetAllWithImagesAsync();
            About aboutParts = await _context.AboutParts.FirstOrDefaultAsync();
            List<Position> positions = await _context.Positions.ToListAsync();
            List<Expert> experts = await _expertService.GetAllAsync();
            List<Blog> blogs = await _blogService.TakeAsync();
            List<InstaSlider> instaSliders = await _sliderInstaService.GetAllAsync();
            HomeVM model = new()
            {
                Categories = categories,
                Products = products,
                AboutParts = aboutParts,
                Experts = experts,
                Positions = positions,
                Blogs = blogs,
                InstaSliders = instaSliders
            };
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddProductToBasket(int? id)
        {
            if (id is null) return BadRequest();

            List<BasketVM> basketProducts = null;

            if (_accessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basketProducts = new List<BasketVM>();
            }


            var dbProduct = await _productService.GetByIdAsync((int)id);


            var existProduct = basketProducts.FirstOrDefault(m => m.Id == (int)id);

            if (existProduct is not null)
            {
                existProduct.Count++;
            }
            else
            {   
                basketProducts.Add(new BasketVM
                {
                    Id = (int)id,
                    Count = 1,
                    Price = dbProduct.Price
                });
            }  


            _accessor.HttpContext.Response.Cookies.Append("basket",JsonConvert.SerializeObject(basketProducts));

            int count = basketProducts.Sum(m=> m.Count);    
            decimal totalPrice = basketProducts.Sum(m=> m.Count * m.Price);    

            return Ok(new {count, totalPrice});
        }
    }
}
