using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Helpers.Extensions;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.ViewModels.Sliders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFrontBackDB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, 
                                IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.ToListAsync();

            List<SliderVM> result = sliders.Select(m => new SliderVM { Id = m.Id, Image = m.Image }).ToList();

            return View(result);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid) return View();

            foreach (var item in request.Images)
            {
                if (!item.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Images", "File must be only Image");
                    return View();
                }

                if (!item.CheckFileSize(200))
                {
                    ModelState.AddModelError("Images", "File size must be less than 200Kb");
                    return View();
                }
            }

            foreach (var item in request.Images)
            {
                string fileName = Guid.NewGuid().ToString() + "-" + item.FileName;

                string path = Path.Combine(_env.WebRootPath, "img", fileName);

                await item.SaveFileToLocalAsync(path);

                await _context.Sliders.AddAsync(new Slider { Image = fileName });
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m=>m.Id == id);  

            if(slider == null) return NotFound();

            string existingFile = Path.Combine(_env.WebRootPath,"img",slider.Image);

            existingFile.DeleteFileFromLocal();

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (slider == null) return NotFound();

            return View(slider);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (slider == null) return NotFound();


            return View(new SliderEditVM { Image = slider.Image});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id,SliderEditVM request)
        {
            if (id is null) return BadRequest();

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (slider == null) return NotFound();

            if (request.NewImage is null) return RedirectToAction(nameof(Index));


            if (!request.NewImage.CheckFileType("image/"))
            {
                ModelState.AddModelError("NewImage", "File must be only Image");
                request.Image = slider.Image;
                return View(request);
            }

            if (!request.NewImage.CheckFileSize(200))
            {
                ModelState.AddModelError("NewImage", "File size must be less than 200Kb");
                request.Image = slider.Image;
                return View(request);
            }

            string oldPath = Path.Combine(_env.WebRootPath, "img", slider.Image);

            oldPath.DeleteFileFromLocal();

            string newFileName = Guid.NewGuid().ToString() + "-" + request.NewImage.FileName;

            string newPath = Path.Combine(_env.WebRootPath, "img", newFileName);

            await request.NewImage.SaveFileToLocalAsync(newPath);

            slider.Image = newFileName;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));


        }
    }
}
