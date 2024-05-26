
using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services.Interfaces;
using FiorelloFrontBackDB.ViewModels.Baskets;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FiorelloFrontBackDB.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _accessor;

        public BasketController(AppDbContext context, 
                                IHttpContextAccessor accessor,
                                IProductService productService)
        {
            _context = context;
            _accessor = accessor;
            _productService = productService;

        }
        public async Task<IActionResult> Index()
        {
              
            List<BasketVM> basketProducts = null;

            if (_accessor.HttpContext.Request.Cookies["basket"] is not null)
            {
                basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basketProducts = new List<BasketVM>();
            }

            var products = await _productService.GetAllAsync();
            
            List<CartVM> cartProducts = new();

            foreach (var product in basketProducts)
            {
                var dbProduct = products.FirstOrDefault(m => m.Id == product.Id);

                cartProducts.Add(new CartVM
                {
                    Id = product.Id,
                    Name = dbProduct.Name,
                    Description = dbProduct.Description,
                    Image = dbProduct.ProductImages.FirstOrDefault().ImageUrl,
                    Category = dbProduct.Category.Name,
                    Price = dbProduct.Price,
                    Count = product.Count,
                    TotalPrice = product.Count * product.Price
                });
            }

            ViewBag.TotalPrice = basketProducts.Sum(x => x.Price*x.Count);

            return View(cartProducts);
        }


        [HttpPost]
        public IActionResult IncreaseProductCount(int? id)
        {
            if (id is null) return BadRequest();

            List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);

            BasketVM existProduct = basketProducts.FirstOrDefault(m => m.Id == (int)id);

            if (existProduct is not null)
            {
                existProduct.Count++;
            }

            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketProducts));


            int count = basketProducts.Sum(m => m.Count);
            decimal totalPrice = basketProducts.Sum(m => m.Count * m.Price);
            int productCount = basketProducts.FirstOrDefault(m => m.Id == (int)id).Count;
            decimal productTotalPrice = existProduct.Count * existProduct.Price;


            return Ok(new {count,totalPrice,productCount, productTotalPrice });
        }


        [HttpPost]
        public IActionResult DecreaseProductCount(int? id)
        {
            if (id is null) return BadRequest();

            List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);

            var existProduct = basketProducts.FirstOrDefault(m => m.Id == (int)id);

            if (existProduct is not null && existProduct.Count > 1)
            {
                existProduct.Count--;
            }

            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketProducts));


            int count = basketProducts.Sum(m => m.Count);
            decimal totalPrice = basketProducts.Sum(m => m.Count * m.Price);
            int productCount = existProduct.Count;
            decimal productTotalPrice = existProduct.Count * existProduct.Price;


            return Ok(new { count, totalPrice,productCount,productTotalPrice});
        }


        [HttpPost]
        public IActionResult DeleteProduct(int? id)
        {
            if (id is null) return BadRequest();

            List<BasketVM> basketProducts = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);

            basketProducts = basketProducts.Where(m => m.Id != (int)id).ToList(); 

            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketProducts));
                

            int count = basketProducts.Sum(m => m.Count);
            decimal totalPrice = basketProducts.Sum(m => m.Count * m.Price);


            return Ok(new { count, totalPrice });
        }

    }
}
