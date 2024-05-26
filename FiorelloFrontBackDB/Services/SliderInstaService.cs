using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFrontBackDB.Services
{
    public class SliderInstaService : ISliderInstaService
    {
        private readonly AppDbContext _context;

        public SliderInstaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<InstaSlider>> GetAllAsync()
        {
            return await _context.InstaSliders.ToListAsync();
        }
    }
}
