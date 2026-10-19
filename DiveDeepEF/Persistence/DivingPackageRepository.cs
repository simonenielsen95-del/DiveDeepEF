using Dive_Deep.Models.Equipment;
using DiveDeepEF.Data;
using Microsoft.EntityFrameworkCore;

namespace DiveDeepEF.Persistence
{
    public class DivingPackageRepository
    {
        private readonly DiveDeepEFContext _context;

        public DivingPackageRepository(DiveDeepEFContext context)
        {
            _context = context;
        }

        public async Task<List<DivingPackage>> GetAllAsync()
        {
            return await _context.DivingPackages
                .Include(p => p.Bcd)
                .Include(p => p.Suit)
                .Include(p => p.Regulator)
                .Include(p => p.Tank)
                .Include(p => p.Fins)
                .Include(p => p.Mask)
                .ToListAsync();
        }

        public async Task<DivingPackage?> GetByIdAsync(int id)
        {
            return await _context.DivingPackages
                .Include(p => p.Bcd)
                .Include(p => p.Suit)
                .Include(p => p.Regulator)
                .Include(p => p.Tank)
                .Include(p => p.Fins)
                .Include(p => p.Mask)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
