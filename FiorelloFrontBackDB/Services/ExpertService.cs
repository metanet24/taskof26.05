using FiorelloFrontBackDB.Data;
using FiorelloFrontBackDB.Models;
using FiorelloFrontBackDB.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FiorelloFrontBackDB.Services
{
    public class ExpertService : IExpertService
    {
        private readonly AppDbContext _context;

        public ExpertService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Expert>> GetAllAsync() => 
            await _context.Experts.Include(m => m.ExpertImages).ToListAsync();
    }
}
