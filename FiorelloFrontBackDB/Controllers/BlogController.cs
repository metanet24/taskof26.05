using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFrontBackDB.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
          
        public async Task<IActionResult> Index()
        {
           ViewBag.count = await _blogService.BlogCountAsync();
           return View(await _blogService.TakeAsync());
        }

        [HttpGet]
        public async Task<IActionResult> ShowMore(int skip)
        {

            List<Blog> blogs = await _blogService.SkipTakeAsync(skip);
            return PartialView("_BlogsPartial", blogs);
        }
    }
}
